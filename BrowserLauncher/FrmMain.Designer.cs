using System.Windows.Forms;
namespace BrowserLauncher
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBrowser = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.rbHttp = new System.Windows.Forms.RadioButton();
            this.rbHttps = new System.Windows.Forms.RadioButton();
            this.btnAddCountry = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewCountry = new System.Windows.Forms.TextBox();
            this.btnAddNewCountry = new System.Windows.Forms.Button();
            this.cbSorting = new System.Windows.Forms.ComboBox();
            this.btnEditBrowsers = new System.Windows.Forms.Button();
            this.btnEditStores = new System.Windows.Forms.Button();
            this.btnEditEnvironments = new System.Windows.Forms.Button();
            this.btnEditCountries = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.savePresetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPresetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.separator = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.goMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnEditParameters = new System.Windows.Forms.Button();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lvPresets = new System.Windows.Forms.ListView();
            this.presets = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPresets = new System.Windows.Forms.Button();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.tbPresets = new System.Windows.Forms.TextBox();
            this.pnlPresets = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.pnlPresets.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBrowser
            // 
            this.lblBrowser.AutoSize = true;
            this.lblBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrowser.Location = new System.Drawing.Point(12, 42);
            this.lblBrowser.Name = "lblBrowser";
            this.lblBrowser.Size = new System.Drawing.Size(56, 13);
            this.lblBrowser.TabIndex = 100;
            this.lblBrowser.Text = "Browser:";
            this.lblBrowser.Click += new System.EventHandler(this.lblBrowser_Click);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(12, 69);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(41, 13);
            this.lblStore.TabIndex = 101;
            this.lblStore.Text = "Store:";
            this.lblStore.Click += new System.EventHandler(this.lblStore_Click);
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvironment.Location = new System.Drawing.Point(12, 96);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(81, 13);
            this.lblEnvironment.TabIndex = 102;
            this.lblEnvironment.Text = "Environment:";
            this.lblEnvironment.Click += new System.EventHandler(this.lblEnvironment_Click);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(12, 123);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(54, 13);
            this.lblCountry.TabIndex = 103;
            this.lblCountry.Text = "Country:";
            this.lblCountry.Click += new System.EventHandler(this.lblCountry_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(15, 176);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(157, 23);
            this.btnReload.TabIndex = 15;
            this.btnReload.Text = "Reset";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(299, 176);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(157, 23);
            this.btnGo.TabIndex = 18;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // rbHttp
            // 
            this.rbHttp.AutoSize = true;
            this.rbHttp.Checked = true;
            this.rbHttp.Location = new System.Drawing.Point(186, 179);
            this.rbHttp.Name = "rbHttp";
            this.rbHttp.Size = new System.Drawing.Size(43, 17);
            this.rbHttp.TabIndex = 16;
            this.rbHttp.TabStop = true;
            this.rbHttp.Text = "http";
            this.rbHttp.UseVisualStyleBackColor = true;
            // 
            // rbHttps
            // 
            this.rbHttps.AutoSize = true;
            this.rbHttps.Location = new System.Drawing.Point(235, 179);
            this.rbHttps.Name = "rbHttps";
            this.rbHttps.Size = new System.Drawing.Size(48, 17);
            this.rbHttps.TabIndex = 17;
            this.rbHttps.Text = "https";
            this.rbHttps.UseVisualStyleBackColor = true;
            // 
            // btnAddCountry
            // 
            this.btnAddCountry.Location = new System.Drawing.Point(344, 118);
            this.btnAddCountry.Name = "btnAddCountry";
            this.btnAddCountry.Size = new System.Drawing.Size(73, 23);
            this.btnAddCountry.TabIndex = 12;
            this.btnAddCountry.Text = "Add Country";
            this.btnAddCountry.UseVisualStyleBackColor = true;
            this.btnAddCountry.Click += new System.EventHandler(this.btnAddCountry_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNewCountry
            // 
            this.txtNewCountry.Location = new System.Drawing.Point(99, 120);
            this.txtNewCountry.Name = "txtNewCountry";
            this.txtNewCountry.Size = new System.Drawing.Size(179, 20);
            this.txtNewCountry.TabIndex = 10;
            // 
            // btnAddNewCountry
            // 
            this.btnAddNewCountry.Location = new System.Drawing.Point(284, 118);
            this.btnAddNewCountry.Name = "btnAddNewCountry";
            this.btnAddNewCountry.Size = new System.Drawing.Size(133, 23);
            this.btnAddNewCountry.TabIndex = 8;
            this.btnAddNewCountry.Text = "Add New Country";
            this.btnAddNewCountry.UseVisualStyleBackColor = true;
            this.btnAddNewCountry.Click += new System.EventHandler(this.btnAddNewCountry_Click);
            // 
            // cbSorting
            // 
            this.cbSorting.BackColor = System.Drawing.SystemColors.Window;
            this.cbSorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSorting.FormattingEnabled = true;
            this.cbSorting.Items.AddRange(new object[] {
            "no sorting",
            "alphabetically"});
            this.cbSorting.Location = new System.Drawing.Point(186, 119);
            this.cbSorting.Name = "cbSorting";
            this.cbSorting.Size = new System.Drawing.Size(92, 21);
            this.cbSorting.TabIndex = 7;
            this.cbSorting.SelectedIndexChanged += new System.EventHandler(this.cbSorting_SelectedIndexChanged);
            // 
            // btnEditBrowsers
            // 
            this.btnEditBrowsers.Location = new System.Drawing.Point(423, 37);
            this.btnEditBrowsers.Name = "btnEditBrowsers";
            this.btnEditBrowsers.Size = new System.Drawing.Size(33, 23);
            this.btnEditBrowsers.TabIndex = 1;
            this.btnEditBrowsers.Text = "Edit";
            this.btnEditBrowsers.UseVisualStyleBackColor = true;
            this.btnEditBrowsers.Click += new System.EventHandler(this.btnEditBrowsers_Click);
            // 
            // btnEditStores
            // 
            this.btnEditStores.Location = new System.Drawing.Point(423, 64);
            this.btnEditStores.Name = "btnEditStores";
            this.btnEditStores.Size = new System.Drawing.Size(33, 23);
            this.btnEditStores.TabIndex = 3;
            this.btnEditStores.Text = "Edit";
            this.btnEditStores.UseVisualStyleBackColor = true;
            this.btnEditStores.Click += new System.EventHandler(this.btnEditStores_Click);
            // 
            // btnEditEnvironments
            // 
            this.btnEditEnvironments.Location = new System.Drawing.Point(423, 91);
            this.btnEditEnvironments.Name = "btnEditEnvironments";
            this.btnEditEnvironments.Size = new System.Drawing.Size(33, 23);
            this.btnEditEnvironments.TabIndex = 5;
            this.btnEditEnvironments.Text = "Edit";
            this.btnEditEnvironments.UseVisualStyleBackColor = true;
            this.btnEditEnvironments.Click += new System.EventHandler(this.btnEditEnvironments_Click);
            // 
            // btnEditCountries
            // 
            this.btnEditCountries.Location = new System.Drawing.Point(423, 118);
            this.btnEditCountries.Name = "btnEditCountries";
            this.btnEditCountries.Size = new System.Drawing.Size(33, 23);
            this.btnEditCountries.TabIndex = 9;
            this.btnEditCountries.Text = "Edit";
            this.btnEditCountries.UseVisualStyleBackColor = true;
            this.btnEditCountries.Click += new System.EventHandler(this.btnEditCountries_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.actionsMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(820, 24);
            this.mainMenu.TabIndex = 19;
            this.mainMenu.Text = "Main";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePresetMenu,
            this.loadPresetMenu,
            this.separator,
            this.exitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // savePresetMenu
            // 
            this.savePresetMenu.Enabled = false;
            this.savePresetMenu.Name = "savePresetMenu";
            this.savePresetMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savePresetMenu.Size = new System.Drawing.Size(187, 22);
            this.savePresetMenu.Text = "Save preset...";
            this.savePresetMenu.Click += new System.EventHandler(this.savePresetMenu_Click);
            // 
            // loadPresetMenu
            // 
            this.loadPresetMenu.Name = "loadPresetMenu";
            this.loadPresetMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadPresetMenu.Size = new System.Drawing.Size(187, 22);
            this.loadPresetMenu.Text = "Load preset...";
            this.loadPresetMenu.Click += new System.EventHandler(this.loadPresetMenu_Click);
            // 
            // separator
            // 
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(184, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenu.Size = new System.Drawing.Size(187, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // actionsMenu
            // 
            this.actionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetMenu,
            this.goMenu});
            this.actionsMenu.Name = "actionsMenu";
            this.actionsMenu.Size = new System.Drawing.Size(59, 20);
            this.actionsMenu.Text = "Actions";
            // 
            // resetMenu
            // 
            this.resetMenu.Name = "resetMenu";
            this.resetMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetMenu.Size = new System.Drawing.Size(143, 22);
            this.resetMenu.Text = "Reset";
            this.resetMenu.Click += new System.EventHandler(this.resetMenu_Click);
            // 
            // goMenu
            // 
            this.goMenu.Enabled = false;
            this.goMenu.Name = "goMenu";
            this.goMenu.Size = new System.Drawing.Size(143, 22);
            this.goMenu.Text = "Go";
            this.goMenu.Click += new System.EventHandler(this.goMenu_Click);
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "preset";
            this.saveFile.Filter = "Preset files|*.preset|All files|*.*";
            // 
            // openFile
            // 
            this.openFile.DefaultExt = "preset";
            this.openFile.Filter = "Preset files|*.preset|All files|*.*";
            // 
            // btnEditParameters
            // 
            this.btnEditParameters.Location = new System.Drawing.Point(424, 147);
            this.btnEditParameters.Name = "btnEditParameters";
            this.btnEditParameters.Size = new System.Drawing.Size(33, 23);
            this.btnEditParameters.TabIndex = 14;
            this.btnEditParameters.Text = "Edit";
            this.btnEditParameters.UseVisualStyleBackColor = true;
            this.btnEditParameters.Click += new System.EventHandler(this.btnEditParameters_Click);
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(13, 152);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(63, 13);
            this.lblParameters.TabIndex = 104;
            this.lblParameters.Text = "Parameters:";
            this.lblParameters.Click += new System.EventHandler(this.lblParameters_Click);
            // 
            // lvPresets
            // 
            this.lvPresets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.presets});
            this.lvPresets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvPresets.GridLines = true;
            this.lvPresets.Location = new System.Drawing.Point(0, 21);
            this.lvPresets.Name = "lvPresets";
            this.lvPresets.ShowItemToolTips = true;
            this.lvPresets.Size = new System.Drawing.Size(319, 111);
            this.lvPresets.TabIndex = 23;
            this.lvPresets.UseCompatibleStateImageBehavior = false;
            this.lvPresets.View = System.Windows.Forms.View.Details;
            this.lvPresets.SelectedIndexChanged += new System.EventHandler(this.lvPresets_SelectedIndexChanged);
            this.lvPresets.Click += new System.EventHandler(this.lvPresets_Click);
            this.lvPresets.DoubleClick += new System.EventHandler(this.lvPresets_DoubleClick);
            // 
            // presets
            // 
            this.presets.Text = "Presets";
            this.presets.Width = 296;
            // 
            // btnPresets
            // 
            this.btnPresets.Location = new System.Drawing.Point(462, 37);
            this.btnPresets.Name = "btnPresets";
            this.btnPresets.Size = new System.Drawing.Size(18, 162);
            this.btnPresets.TabIndex = 19;
            this.btnPresets.Text = "<";
            this.btnPresets.UseVisualStyleBackColor = true;
            this.btnPresets.Click += new System.EventHandler(this.btnPresets_Click);
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Enabled = false;
            this.btnAddParameter.Location = new System.Drawing.Point(394, 147);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(23, 23);
            this.btnAddParameter.TabIndex = 108;
            this.btnAddParameter.Text = "+";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // tbPresets
            // 
            this.tbPresets.Location = new System.Drawing.Point(0, 0);
            this.tbPresets.Name = "tbPresets";
            this.tbPresets.Size = new System.Drawing.Size(298, 20);
            this.tbPresets.TabIndex = 21;
            this.tbPresets.TextChanged += new System.EventHandler(this.tbPresets_TextChanged);
            // 
            // pnlPresets
            // 
            this.pnlPresets.Controls.Add(this.btnClear);
            this.pnlPresets.Controls.Add(this.tbPresets);
            this.pnlPresets.Controls.Add(this.lvPresets);
            this.pnlPresets.Location = new System.Drawing.Point(486, 38);
            this.pnlPresets.Name = "pnlPresets";
            this.pnlPresets.Size = new System.Drawing.Size(319, 132);
            this.pnlPresets.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(298, -1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(22, 22);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "X";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(485, 176);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 23);
            this.btnSave.TabIndex = 109;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(648, 176);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(157, 23);
            this.btnDelete.TabIndex = 110;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 213);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPresets);
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.btnEditParameters);
            this.Controls.Add(this.lblParameters);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.btnEditCountries);
            this.Controls.Add(this.btnEditEnvironments);
            this.Controls.Add(this.btnEditStores);
            this.Controls.Add(this.btnEditBrowsers);
            this.Controls.Add(this.cbSorting);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbHttps);
            this.Controls.Add(this.rbHttp);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblEnvironment);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lblBrowser);
            this.Controls.Add(this.btnAddCountry);
            this.Controls.Add(this.btnAddNewCountry);
            this.Controls.Add(this.txtNewCountry);
            this.Controls.Add(this.pnlPresets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::BrowserLauncher.Properties.Resources.aosp_browser_icon;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browser Launcher";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.pnlPresets.ResumeLayout(false);
            this.pnlPresets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrowser;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RadioButton rbHttp;
        private System.Windows.Forms.RadioButton rbHttps;
        private System.Windows.Forms.Button btnAddCountry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewCountry;
        private System.Windows.Forms.Button btnAddNewCountry;
        private System.Windows.Forms.ComboBox cbSorting;
        private System.Windows.Forms.Button btnEditBrowsers;
        private System.Windows.Forms.Button btnEditStores;
        private System.Windows.Forms.Button btnEditEnvironments;
        private System.Windows.Forms.Button btnEditCountries;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem savePresetMenu;
        private System.Windows.Forms.ToolStripMenuItem loadPresetMenu;
        private System.Windows.Forms.ToolStripSeparator separator;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.OpenFileDialog openFile;
        private ToolStripMenuItem actionsMenu;
        private ToolStripMenuItem resetMenu;
        private ToolStripMenuItem goMenu;
        private Button btnEditParameters;
        private Label lblParameters;
        private ListView lvPresets;
        private Button btnPresets;
        private Button btnAddParameter;
        private TextBox tbPresets;
        private Panel pnlPresets;
        private Button btnClear;
        private Button btnSave;
        private Button btnDelete;
        private ColumnHeader presets;
    }
}

