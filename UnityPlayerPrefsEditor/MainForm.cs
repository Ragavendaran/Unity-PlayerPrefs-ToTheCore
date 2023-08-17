using System.Data;
using System.Text.RegularExpressions;

namespace UnityPlayerPrefsEditor {

    public partial class MainForm : Form {
        private readonly RegistryEditor registryLister;
        private DataTable dataTable;

        public MainForm() {
            InitializeComponent();

            registryLister = new RegistryEditor();

            dataTable = new DataTable();

            dataTable.Columns.Add("Key", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Value", typeof(string));

            RefreshButton_Click(this, null);
            PrefsDataGridView.DataSource = dataTable;

            PrefsDataGridView.Columns[0].Visible = false;
            PrefsDataGridView.Columns[0].ReadOnly = true;
            PrefsDataGridView.Columns[1].ReadOnly = true;
            PrefsDataGridView.Columns[2].ReadOnly = true;
            PrefsDataGridView.Columns[1].FillWeight = 100;
            PrefsDataGridView.Columns[2].FillWeight = 30;
            PrefsDataGridView.Columns[3].FillWeight = 70;
        }

        private void RefreshButton_Click(object? sender, EventArgs? s) {
            Color control = RefreshButton.BackColor;
            RefreshButton.BackColor = Color.Yellow;

            dataTable.Clear();
            registryLister.RefreshList();

            string pattern = @"^(.*)_h\d+$";

            foreach (var pref in registryLister.playerPrefs) {
                dataTable.Rows.Add(
                    pref.Value.key,
                    Regex.Match(pref.Value.key, pattern).Groups[1].Value,
                    pref.Value.type,
                    pref.Value.value.ToString()
                );
            }
            dataTable.AcceptChanges();

            GuideLabel.Visible = registryLister.playerPrefs.Count == 0;
            SearchTextBox.Enabled = registryLister.playerPrefs.Count != 0;

            RefreshButton.BackColor = control;
        }

        private void SearchTextBox_TextChanged(object? sender, EventArgs? e) {
            if (string.IsNullOrEmpty(SearchTextBox.Text)) {
                dataTable.DefaultView.RowFilter = string.Empty;
            } else {
                dataTable.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", SearchTextBox.Text);
            }
        }

        private void PrefsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3) {
                DataGridView dataGridView = (DataGridView)sender;
                string newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()!;
                string key = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()!;
                try {
                    registryLister.UpdatePref(key, newValue);
                    dataTable.AcceptChanges();
                } catch {
                    dataTable.RejectChanges();
                }
            }
        }
    }
}