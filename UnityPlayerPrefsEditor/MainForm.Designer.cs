using System.Drawing;

namespace UnityPlayerPrefsEditor {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            PrefsDataGridView = new DataGridView();
            TopPanel = new Panel();
            SearchTextBox = new TextBox();
            SearchLabel = new Label();
            RefreshButton = new Button();
            GuideLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)PrefsDataGridView).BeginInit();
            TopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PrefsDataGridView
            // 
            PrefsDataGridView.AllowUserToAddRows = false;
            PrefsDataGridView.AllowUserToDeleteRows = false;
            PrefsDataGridView.AllowUserToOrderColumns = true;
            PrefsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PrefsDataGridView.BackgroundColor = SystemColors.Control;
            PrefsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PrefsDataGridView.Dock = DockStyle.Fill;
            PrefsDataGridView.Location = new Point(0, 31);
            PrefsDataGridView.Name = "PrefsDataGridView";
            PrefsDataGridView.RowTemplate.Height = 25;
            PrefsDataGridView.Size = new Size(464, 570);
            PrefsDataGridView.TabIndex = 0;
            PrefsDataGridView.CellValueChanged += PrefsDataGridView_CellValueChanged;
            // 
            // TopPanel
            // 
            TopPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopPanel.BackColor = SystemColors.Control;
            TopPanel.Controls.Add(SearchTextBox);
            TopPanel.Controls.Add(SearchLabel);
            TopPanel.Controls.Add(RefreshButton);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.ImeMode = ImeMode.Disable;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Padding = new Padding(4);
            TopPanel.Size = new Size(464, 31);
            TopPanel.TabIndex = 1;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Dock = DockStyle.Fill;
            SearchTextBox.Enabled = false;
            SearchTextBox.Location = new Point(52, 4);
            SearchTextBox.MaximumSize = new Size(320, 0);
            SearchTextBox.MaxLength = 512;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(320, 23);
            SearchTextBox.TabIndex = 0;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Dock = DockStyle.Left;
            SearchLabel.Location = new Point(4, 4);
            SearchLabel.Margin = new Padding(3);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Padding = new Padding(0, 4, 0, 4);
            SearchLabel.Size = new Size(48, 23);
            SearchLabel.TabIndex = 1;
            SearchLabel.Text = "Search: ";
            // 
            // RefreshButton
            // 
            RefreshButton.AutoSize = true;
            RefreshButton.Dock = DockStyle.Right;
            RefreshButton.Location = new Point(404, 4);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(56, 23);
            RefreshButton.TabIndex = 2;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // GuideLabel
            // 
            GuideLabel.Dock = DockStyle.Fill;
            GuideLabel.Location = new Point(0, 31);
            GuideLabel.Margin = new Padding(0);
            GuideLabel.Name = "GuideLabel";
            GuideLabel.Padding = new Padding(16);
            GuideLabel.Size = new Size(464, 570);
            GuideLabel.TabIndex = 2;
            GuideLabel.Text = "No save data found, open the game and hit refresh button to populate.\r\n";
            GuideLabel.TextAlign = ContentAlignment.TopCenter;
            GuideLabel.UseMnemonic = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 601);
            Controls.Add(GuideLabel);
            Controls.Add(PrefsDataGridView);
            Controls.Add(TopPanel);
            ImeMode = ImeMode.Off;
            Name = "MainForm";
            Text = "PlayerPrefs Editor v0.1.0 [ToTheCore]";
            ((System.ComponentModel.ISupportInitialize)PrefsDataGridView).EndInit();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView PrefsDataGridView;
        private Panel TopPanel;
        private TextBox SearchTextBox;
        private Label SearchLabel;
        private Label GuideLabel;
        private Button RefreshButton;
    }
}