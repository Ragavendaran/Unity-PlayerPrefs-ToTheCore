using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;

namespace UnityPlayerPrefsEditor {

    public enum PrefType {
        Int, Double, String
    }

    public struct Pref {
        public string name;
        public string key;
        public dynamic value;
        public PrefType type;

        public static implicit operator Pref((string, object) tuple) {
            (string key, object value) = tuple;

            //Possible incorrect type selection, behaves as expected in tests.
            try {
                int value_int = (int)value;
                return new Pref() { name = key, key = key, value = value_int, type = PrefType.Int };
            } catch { }

            try {
                long value_double = (long)value;
                var bytes = BitConverter.GetBytes(value_double);
                double dubs = BitConverter.ToDouble(bytes, 0);
                return new Pref() { name = key, key = key, value = dubs, type = PrefType.Double };
            } catch { }

            return new Pref() { name = key, key = key, value = Encoding.UTF8.GetString((byte[])value), type = PrefType.String };
        }
    }

    public class RegistryEditor {
        public Dictionary<string, Pref> playerPrefs;
        public readonly string keyPath = @"SOFTWARE\SomethingExtra\ToTheCore";

        public RegistryEditor() {
            playerPrefs = new Dictionary<string, Pref>();
            RefreshList();
        }

        public void RefreshList() {
            playerPrefs.Clear();
            using RegistryKey? baseKey = Registry.CurrentUser.OpenSubKey(keyPath);
            if (baseKey != null) {
                string[] valueNames = baseKey.GetValueNames();

                foreach (string valueName in valueNames) {
                    Pref pref = (valueName, baseKey.GetValue(valueName)!);
                    playerPrefs.Add(valueName, pref);
                }
            }
        }

        public void UpdatePref(string key, string value) {
            Pref pref = playerPrefs![key];
            if (pref.type == PrefType.Int) {
                using RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(keyPath, true)!;
                baseKey.SetValue(key, int.Parse(value), RegistryValueKind.DWord);
                return;
            }
            if (pref.type == PrefType.Double) {
                NonStandardWriter.WriteDoubleInDWord(keyPath, key, double.Parse(value));
                return;
            }
            if (pref.type == PrefType.String) {
                using RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(keyPath, true)!;
                baseKey.SetValue(key, Encoding.UTF8.GetBytes(value + '\0'), RegistryValueKind.Binary);
                return;
            }
        }
    }

    // Credit https://stackoverflow.com/questions/52571559/how-to-write-64-bit-value-as-dword-to-windows-registry
    internal static class NonStandardWriter {

        [DllImport("advapi32.dll")]
        private static extern uint RegSetValueEx(
            UIntPtr hKey,
            [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
            int Reserved,
            RegistryValueKind dwType,
            IntPtr lpData,
            int cbData
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        private static extern uint RegOpenKeyEx(
            IntPtr hKey,
            string subKey,
            int ulOptions,
            int samDesired,
            out UIntPtr hkResult
        );

        [DllImport("advapi32.dll")]
        private static extern int RegCloseKey(UIntPtr hKey);

        private static readonly IntPtr HKEY_CURRENT_USER = new(-2147483647);

        internal static bool WriteDoubleInDWord(string path, string valName, double value) {
            UIntPtr hKey = UIntPtr.Zero;
            try {
                if (RegOpenKeyEx(HKEY_CURRENT_USER, path, 0, 0x20006, out hKey) != 0)
                    return false;

                int size = 8;
                IntPtr pData = Marshal.AllocHGlobal(size);
                Marshal.WriteInt64(pData, BitConverter.DoubleToInt64Bits(value));
                if (RegSetValueEx(hKey, valName, 0, RegistryValueKind.DWord, pData, size) != 0) {
                    return false;
                }
            } finally {
                if (hKey != UIntPtr.Zero)
                    _ = RegCloseKey(hKey);
            }
            return true;
        }
    }
}