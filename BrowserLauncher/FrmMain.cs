using BrowserLauncher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BrowserLauncher
{
    public partial class frmMain : Form
    {
        private SuggestComboBox cbBrowser, cbStore, cbEnvironment, cbCountry, cbParameters;
        
        private List<Browser> browsers { get; set; }
        private List<Store> stores { get; set; }
        private List<String> environments { get; set; }
        private List<String> countries { get; set; }
        private List<String> parameters { get; set; }

        private List<String> queue { get; set; }

        private String strAppDir { get; set; }
        private const String ONLINE = "ONLINE";

        public class Preset
        {
            public string path { get; set; }
            public int index { get; set; }
        }

        public frmMain()
        {
            InitializeComponent();
            lvPresets.HeaderStyle = ColumnHeaderStyle.None;
            InitializeComboBox();
            strAppDir = Application.StartupPath;
            Reload();
        }

        private void InitializeComboBox()
        {
            #region Browser ComboBox
            this.cbBrowser = new SuggestComboBox();
            this.cbBrowser.FilterRule = (item, text) => item.ToLower().Contains(text.ToLower().Trim());
            this.cbBrowser.FormattingEnabled = true;
            this.cbBrowser.Location = new System.Drawing.Point(99, 39);
            this.cbBrowser.Size = new System.Drawing.Size(318, 21);
            this.cbBrowser.Name = "cbBrowser";
            //this.cbBrowser.PropertySelector = null;
            this.cbBrowser.SuggestBoxHeight = this.ClientSize.Height - (cbBrowser.Location.Y + cbBrowser.Size.Height);
            this.cbBrowser.MaxSuggestBoxHeight = this.ClientSize.Height - (cbBrowser.Location.Y + cbBrowser.Size.Height);
            //this.cbBrowser.SuggestListOrderRule = null;
            this.cbBrowser.TabIndex = 0;
            this.cbBrowser.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.Controls.Add(this.cbBrowser);
            #endregion
            #region Store ComboBox
            this.cbStore = new SuggestComboBox();
            this.cbStore.FilterRule = (item, text) => item.ToLower().Contains(text.ToLower().Trim());
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(99, 66);
            this.cbStore.Size = new System.Drawing.Size(318, 21);
            this.cbStore.Name = "cbStore";
            //this.cbStore.PropertySelector = null;
            this.cbStore.SuggestBoxHeight = this.ClientSize.Height - (cbStore.Location.Y + cbStore.Size.Height);
            this.cbStore.MaxSuggestBoxHeight = this.ClientSize.Height - (cbStore.Location.Y + cbStore.Size.Height);
            //this.cbStore.SuggestListOrderRule = null;
            this.cbStore.TabIndex = 2;
            this.cbStore.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.Controls.Add(this.cbStore);
            #endregion
            #region Environment ComboBox
            this.cbEnvironment = new SuggestComboBox();
            this.cbEnvironment.FilterRule = (item, text) => item.ToLower().Contains(text.ToLower().Trim());
            this.cbEnvironment.FormattingEnabled = true;
            this.cbEnvironment.Location = new System.Drawing.Point(99, 93);
            this.cbEnvironment.Size = new System.Drawing.Size(318, 21);
            this.cbEnvironment.Name = "cbEnvironment";
            //this.cbEnvironment.PropertySelector = null;
            this.cbEnvironment.SuggestBoxHeight = this.ClientSize.Height - (cbEnvironment.Location.Y + cbEnvironment.Size.Height);
            this.cbEnvironment.MaxSuggestBoxHeight = this.ClientSize.Height - (cbEnvironment.Location.Y + cbEnvironment.Size.Height);
            //this.cbEnvironment.SuggestListOrderRule = null;
            this.cbEnvironment.TabIndex = 4;
            this.cbEnvironment.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.Controls.Add(this.cbEnvironment);
            #endregion
            #region Country ComboBox
            this.cbCountry = new SuggestComboBox();
            this.cbCountry.FilterRule = (item, text) => item.ToLower().Contains(text.ToLower().Trim());
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(99, 119);
            this.cbCountry.Size = new System.Drawing.Size(81, 21);
            this.cbCountry.Name = "cbCountry";
            //this.cbCountry.PropertySelector = null;
            this.cbCountry.SuggestBoxHeight = this.ClientSize.Height - (cbCountry.Location.Y + cbCountry.Size.Height);
            this.cbCountry.MaxSuggestBoxHeight = this.ClientSize.Height - (cbCountry.Location.Y + cbCountry.Size.Height);
            //this.cbCountry.SuggestListOrderRule = null;
            this.cbCountry.TabIndex = 6;
            this.cbCountry.MaxLength = 2;
            this.cbCountry.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.Controls.Add(this.cbCountry);
            #endregion
            #region Parameters ComboBox
            this.cbParameters = new SuggestComboBox();
            this.cbParameters.FilterRule = (item, text) => item.ToLower().Contains(text.ToLower().Trim());
            this.cbParameters.FormattingEnabled = true;
            this.cbParameters.Location = new System.Drawing.Point(99, 149);
            this.cbParameters.Size = new System.Drawing.Size(289, 21);
            this.cbParameters.Name = "cbParameters";
            //this.cbParameters.PropertySelector = null;
            this.cbParameters.SuggestBoxHeight = this.ClientSize.Height - (cbCountry.Location.Y + cbCountry.Size.Height);
            this.cbParameters.MaxSuggestBoxHeight = this.ClientSize.Height - (cbCountry.Location.Y + cbCountry.Size.Height);
            //this.cbParameters.SuggestListOrderRule = null;
            this.cbParameters.TabIndex = 13;
            this.cbParameters.TextChanged += new System.EventHandler(this.cbParameters_TextChanged);
            this.cbParameters.DropDown += new System.EventHandler(this.AdjustWidthComboBox_DropDown);
            this.Controls.Add(this.cbParameters);
            #endregion
        }

        private void EnableControls()
        {
            lblBrowser.Enabled = true;
            cbBrowser.Enabled = true;
            btnEditBrowsers.Enabled = true;
            lblStore.Enabled = true;
            cbStore.Enabled = true;
            btnEditStores.Enabled = true;
            lblEnvironment.Enabled = true;
            cbEnvironment.Enabled = true;
            btnEditEnvironments.Enabled = true;
            lblCountry.Enabled = true;
            cbCountry.Enabled = true;
            btnEditCountries.Enabled = true;
            btnAddNewCountry.Enabled = true;
            txtNewCountry.Enabled = true;
            btnCancel.Enabled = true;
            btnAddCountry.Enabled = true;
            cbSorting.Enabled = true;
            lblParameters.Enabled = true;
            cbParameters.Enabled = true;
            btnEditParameters.Enabled = true;
            rbHttp.Enabled = true;
            rbHttps.Enabled = true;
            btnSave.Enabled = true;
            btnPresets.Enabled = true;
        }

        private void DisableControls()
        {
            lblBrowser.Enabled = false;
            cbBrowser.Enabled = false;
            btnEditBrowsers.Enabled = false;
            lblStore.Enabled = false;
            cbStore.Enabled = false;
            btnEditStores.Enabled = false;
            lblEnvironment.Enabled = false;
            cbEnvironment.Enabled = false;
            btnEditEnvironments.Enabled = false;
            lblCountry.Enabled = false;
            cbCountry.Enabled = false;
            btnEditCountries.Enabled = false;
            btnAddNewCountry.Enabled = false;
            txtNewCountry.Enabled = false;
            btnCancel.Enabled = false;
            btnAddCountry.Enabled = false;
            cbSorting.Enabled = false;
            lblParameters.Enabled = false;
            cbParameters.Enabled = false;
            btnEditParameters.Enabled = false;
            rbHttp.Enabled = false;
            rbHttps.Enabled = false;
            btnSave.Enabled = false;
            btnPresets.Enabled = false;
        }

        private void Init()
        {
            cbBrowser.ResetText();
            cbBrowser.SelectedIndex = -1;
            cbStore.ResetText();
            cbStore.SelectedIndex = -1;
            cbEnvironment.ResetText();
            cbEnvironment.SelectedIndex = -1;
            cbCountry.ResetText();
            cbCountry.SelectedIndex = -1;
            cbParameters.ResetText();
            cbParameters.SelectedIndex = -1;
            LoadBrowsers();
            LoadStores();
            LoadEnvironments();
            tbPresets.Clear();
            LoadPresets();
            cbSorting.SelectedIndex = 0;
            LoadParameters();
            rbHttp.Checked = true;
        }

        private void AddNewCountry()
        {
            string filename = strAppDir + "\\config\\countries.config";
            bool skipAddNewCountry = false;
            string[] lineOfContents = File.ReadAllLines(filename);
            try
            {
                foreach (string line in lineOfContents)
                {
                    if (txtNewCountry.Text.Equals(String.Empty))
                    {
                        skipAddNewCountry = true;
                        MessageBox.Show("Country cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else if (txtNewCountry.Text.Equals(line))
                    {
                        skipAddNewCountry = true;
                        MessageBox.Show("Country " + txtNewCountry.Text.ToUpper() + " already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbCountry.SelectedIndex = cbCountry.FindStringExact(txtNewCountry.Text);
                        txtNewCountry.Text = String.Empty;
                        ShowDefaultView();
                        break;
                    }
                    else if ((txtNewCountry.Text.Length != 2))
                    {
                        skipAddNewCountry = true;
                        MessageBox.Show(txtNewCountry.Text.ToUpper() + " is not a valid country code: must be two characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (!skipAddNewCountry)
                {
                    StreamWriter sw = File.AppendText(filename);
                    sw.Write(Environment.NewLine + txtNewCountry.Text);
                    sw.Close();
                    sw.Dispose();
                    LoadCountries(false);
                    cbCountry.SelectedIndex = cbCountry.FindStringExact(txtNewCountry.Text);
                    txtNewCountry.Text = String.Empty;
                    ShowDefaultView();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewParameter()
        {
            string filename = strAppDir + "\\config\\parameters.config";
            try
            {
                StreamWriter sw = File.AppendText(filename);
                sw.Write(Environment.NewLine + cbParameters.Text);
                sw.Close();
                sw.Dispose();
                LoadParameters();
                btnAddParameter.Enabled = false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDefaultView()
        {
            cbCountry.Show();
            cbSorting.Show();
            btnAddNewCountry.Show();
            btnAddCountry.Hide();
            btnAddCountry.SendToBack();
            btnCancel.Hide();
            btnCancel.SendToBack();
            txtNewCountry.Hide();
            txtNewCountry.SendToBack();
        }

        private void ShowAddNewCountryView()
        {
            txtNewCountry.Show();
            btnCancel.Show();
            btnAddCountry.Show();
            cbCountry.Hide();
            cbCountry.SendToBack();
            cbSorting.Hide();
            cbSorting.SendToBack();
            btnAddNewCountry.Hide();
            btnAddNewCountry.SendToBack();
        }

        private void LoadBrowsers()
        {
            LoadBrowsers(String.Empty);
        }

        private void LoadBrowsers(string filter)
        {
            string filename = strAppDir + "\\config\\browsers.config";
            int count = 0;
            try
            {
                cbBrowser.Items.Clear();
                browsers = new List<Browser>();
                string[] lineOfContents = File.ReadAllLines(filename);
                foreach (string line in lineOfContents)
                {
                    if (count > 0 && (filter.Equals(String.Empty) || line.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {
                        string[] tokens = line.Split(',');
                        if (tokens.Length > 1)
                        {
                            Browser temp = new Browser();
                            temp.Name = tokens[0];
                            temp.Target = tokens[1];

                            if (tokens.Length > 2)
                                temp.Args = tokens[2];
                            else
                                temp.Args = String.Empty;

                            browsers.Add(temp);
                            cbBrowser.Items.Add(tokens[0]);
                        }
                    }
                    count++;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: browsers cannot be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadStores()
        {
            LoadStores(String.Empty);
        }

        private void LoadStores(string filter)
        {
            string filename = strAppDir + "\\config\\stores.config";
            int count = 0;
            try
            {
                cbStore.Items.Clear();
                stores = new List<Store>();
                string[] lineOfContents = File.ReadAllLines(filename);
                foreach (string line in lineOfContents)
                {
                    if (count > 0 && (filter.Equals(String.Empty) || line.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {
                        string[] tokens = line.Split(',');
                        if (tokens.Length > 1)
                        {
                            Store temp = new Store();
                            temp.Name = tokens[0];
                            temp.Value = tokens[1];
                            temp.Url = tokens[2];
                            stores.Add(temp);
                            cbStore.Items.Add(tokens[0]);
                        }
                    }
                    count++;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: stores cannot be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadEnvironments()
        {
            LoadEnvironments(String.Empty);
        }

        private void LoadEnvironments(string filter)
        {
            string filename = strAppDir + "\\config\\environments.config";
            int count = 0;
            try
            {
                cbEnvironment.Items.Clear();
                environments = new List<string>();
                string[] lineOfContents = File.ReadAllLines(filename);
                if (filter.Equals(String.Empty) || ONLINE.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    environments.Add(ONLINE);
                    cbEnvironment.Items.Add(ONLINE);
                }
                foreach (string line in lineOfContents)
                {
                    if (count > 0 && (filter.Equals(String.Empty) || line.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {
                        environments.Add(line);
                        if (line.Substring(0, 1).Equals("-") || line.Substring(0, 1).Equals("."))
                        {
                            cbEnvironment.Items.Add(line.Substring(1));
                        }
                        else
                        {
                            cbEnvironment.Items.Add(line);
                        }
                    }
                    count++;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: environments cannot be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadCountries(bool sorted)
        {
            LoadCountries(String.Empty, sorted);
        }

        private void LoadCountries(string filter, bool sorted)
        {
            string filename = strAppDir + "\\config\\countries.config";
            int count = 0;
            try
            {
                cbCountry.Items.Clear();
                cbCountry.Sorted = sorted;
                countries = new List<string>();
                string[] lineOfContents = File.ReadAllLines(filename);
                foreach (string line in lineOfContents)
                {
                    if (count > 0 && (filter.Equals(String.Empty) || line.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {
                        countries.Add(line);
                        cbCountry.Items.Add(line);
                    }
                    count++;
                }
                if (sorted)
                {
                    countries.Sort();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: countries cannot be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadParameters()
        {
            LoadParameters(String.Empty);
        }

        private void LoadParameters(string filter)
        {
            string filename = strAppDir + "\\config\\parameters.config";
            int count = 0;
            try
            {
                cbParameters.Items.Clear();
                parameters = new List<string>();
                string[] lineOfContents = File.ReadAllLines(filename);
                foreach (string line in lineOfContents)
                {
                    if (count > 0 && (filter.Equals(String.Empty) || line.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0))
                    {
                        parameters.Add(line);
                        cbParameters.Items.Add(line);
                    }
                    count++;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: parameters cannot be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Reset()
        {
            btnGo.Enabled = false;
            goMenu.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Run()
        {
            if (browsers.Count == 0 || cbBrowser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a browser!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (stores.Count == 0 || cbStore.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a store!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (environments.Count == 0 || cbEnvironment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an environment!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((countries.Count == 0 || cbCountry.SelectedIndex == -1) && cbParameters.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please select a country!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string url, prefix = rbHttps.Checked ? "https://" : "http://";
            if (environments.ElementAt(cbEnvironment.SelectedIndex).Equals(ONLINE))
            {
                url = prefix + stores.ElementAt(cbStore.SelectedIndex).Url;
            }
            else
            {
                url = prefix + stores.ElementAt(cbStore.SelectedIndex).Value + environments.ElementAt(cbEnvironment.SelectedIndex);
            }
            if (!cbParameters.Text.Equals(String.Empty))
            {
                url += cbParameters.Text;
            }
            else
            {
                url += "/" + countries.ElementAt(cbCountry.SelectedIndex);
            }
            string browserTarget = browsers.ElementAt(cbBrowser.SelectedIndex).Target;
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = browserTarget;
                startInfo.Arguments = browsers.ElementAt(cbBrowser.SelectedIndex).Args + " " + url;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("File \"" + browserTarget.Substring(browserTarget.LastIndexOf("\\") + 1) + "\" not found: unable to start this browser.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Launch()
        {
            string filepath = strAppDir + "\\config\\";
            List<Preset> q = new List<Preset>();
            if (lvPresets.SelectedItems.Count > 1)
            {
                foreach (ListViewItem currentItem in lvPresets.SelectedItems)
                {
                    string queueItem = filepath + currentItem.Text + ".preset";
                    Preset p = new Preset();
                    p.path = queueItem;
                    p.index = currentItem.Index;
                    q.Add(p);
                }
                foreach (Preset p in q)
                {
                    LoadPreset(p.path);
                    Run();
                }
                Reload();
                foreach (Preset p in q)
                {
                    lvPresets.Items[p.index].Selected = true;
                    lvPresets.Items[p.index].Focused = true;
                }
                lvPresets.Select();
                btnGo.Enabled = true;
                btnDelete.Enabled = false;
            }
            else
            {
                Run();
            }
        }

        private void Reload()
        {
            ShowDefaultView();
            Init();
        }

        private void HideCountry()
        {
            lblCountry.Enabled = false;
            cbCountry.Enabled = false;
            cbSorting.Enabled = false;
            btnAddNewCountry.Enabled = false;
            txtNewCountry.Enabled = false;
            btnCancel.Enabled = false;
            btnAddCountry.Enabled = false;
            btnEditCountries.Enabled = false;
        }

        private void ShowCountry()
        {
            lblCountry.Enabled = true;
            cbCountry.Enabled = true;
            cbSorting.Enabled = true;
            btnAddNewCountry.Enabled = true;
            txtNewCountry.Enabled = true;
            btnCancel.Enabled = true;
            btnAddCountry.Enabled = true;
            btnEditCountries.Enabled = true;
        }
        
        #region Preset Management
        private void LoadPresets()
        {
            LoadPresets(String.Empty);
        }

        private void LoadPresets(string filter)
        {
            string filename, configPath = strAppDir + "\\config";
            string[] files = Directory.GetFiles(configPath);
            try
            {
                lvPresets.Items.Clear();
                foreach (string file in files)
                {
                    if (file.EndsWith(".preset"))
                    {
                        filename = file.Substring(file.LastIndexOf("\\") + 1);
                        filename = filename.Substring(0, filename.LastIndexOf("."));
                        if (filter.Equals(String.Empty) || filename.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            lvPresets.Items.Add(filename);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowPresets()
        {
            this.Size = new Size(836, 252);
            this.ResizeRedraw = true;
            pnlPresets.BringToFront();
            pnlPresets.Show();
            btnDelete.BringToFront();
            btnDelete.Show();
            btnSave.BringToFront();
            btnSave.Show();
            btnPresets.Text = "<";
            this.Refresh();
        }

        private void HidePresets()
        {
            this.Size = new Size(510, 252);
            this.ResizeRedraw = true;
            btnSave.Hide();
            btnSave.SendToBack();
            btnDelete.Hide();
            btnDelete.SendToBack();
            pnlPresets.Hide();
            pnlPresets.SendToBack();
            btnPresets.Text = ">";
        }

        private void SavePreset(string filename)
        {
            if (browsers.Count == 0 || cbBrowser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a browser!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (stores.Count == 0 || cbStore.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a store!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (environments.Count == 0 || cbEnvironment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an environment!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((countries.Count == 0 || cbCountry.SelectedIndex == -1) && cbParameters.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please select a country!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] presets = new string[7];
            for (int i = 0; i < 7; i++)
            {
                presets[0] = "sorting=" + cbSorting.Text;
                presets[1] = "browser=" + cbBrowser.Text;
                presets[2] = "store=" + cbStore.Text;
                presets[3] = "environment=" + cbEnvironment.Text;
                presets[4] = "country=" + cbCountry.Text;
                presets[5] = "parameters=" + cbParameters.Text;
                presets[6] = "protocol=" + (rbHttp.Checked ? "http" : "https");
            }
            File.WriteAllLines(filename, presets);
        }

        private void LoadPreset(string filename)
        {
            try
            {
                ShowDefaultView();
                string[] presets = File.ReadAllLines(filename);
                int count = 0;
                foreach (string preset in presets)
                {
                    string temp = preset.Substring(preset.IndexOf("=") + 1);
                    if (!temp.Equals(string.Empty))
                    {
                        switch (count)
                        {
                            case 0:
                                cbSorting.SelectedIndex = cbSorting.FindStringExact(temp);
                                break;
                            case 1:
                                cbBrowser.SelectedIndex = cbBrowser.FindStringExact(temp);
                                break;
                            case 2:
                                cbStore.SelectedIndex = cbStore.FindStringExact(temp);
                                break;
                            case 3:
                                cbEnvironment.SelectedIndex = cbEnvironment.FindStringExact(temp);
                                break;
                            case 4:
                                cbCountry.SelectedIndex = cbCountry.FindStringExact(temp);
                                break;
                            case 5:
                                if (cbParameters.FindStringExact(temp) == -1) { cbParameters.Text = temp; }
                                else { cbParameters.SelectedIndex = cbParameters.FindStringExact(temp); }
                                break;
                            case 6:
                                if (temp.Equals("http")) { rbHttp.Checked = true; }
                                else if (temp.Equals("https")) { rbHttps.Checked = true; }
                                break;
                            default:
                                break;
                        }
                    }
                    count++;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void CheckComboBox()
        {
            if ((browsers.Count > 0 && cbBrowser.SelectedIndex > -1) && (stores.Count > 0 && cbStore.SelectedIndex > -1) && (environments.Count > 0
                && cbEnvironment.SelectedIndex > -1) && ((countries.Count > 0 && cbCountry.SelectedIndex > -1) || !cbParameters.Text.Equals(String.Empty)))
            {
                savePresetMenu.Enabled = true;
                btnSave.Enabled = true;
                btnGo.Enabled = true;
                goMenu.Enabled = true;
            }
            else
            {
                goMenu.Enabled = false;
                btnGo.Enabled = false;
                btnSave.Enabled = false;
                savePresetMenu.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            EnableControls();
            Reset();
            Reload();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Launch();
        }

        private void btnAddNewCountry_Click(object sender, EventArgs e)
        {
            txtNewCountry.Text = String.Empty;
            ShowAddNewCountryView();
            CheckComboBox();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowDefaultView();
            cbCountry.SelectedIndex = cbCountry.FindStringExact(cbCountry.Text);
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            AddNewCountry();
        }

        private void lblParameters_Click(object sender, EventArgs e)
        {
            cbParameters.ResetText();
            cbParameters.SelectedIndex = -1;
            LoadParameters();
        }

        private void lblCountry_Click(object sender, EventArgs e)
        {
            cbCountry.ResetText();
            cbCountry.SelectedIndex = -1;
            LoadCountries(false);
            ShowDefaultView();
            
        }

        private void lblEnvironment_Click(object sender, EventArgs e)
        {
            cbEnvironment.ResetText();
            cbEnvironment.SelectedIndex = -1;
            LoadEnvironments();
        }

        private void lblStore_Click(object sender, EventArgs e)
        {
            cbStore.ResetText();
            cbStore.SelectedIndex = -1;
            LoadStores();
        }

        private void lblBrowser_Click(object sender, EventArgs e)
        {
            cbBrowser.ResetText();
            cbBrowser.SelectedIndex = -1;
            LoadBrowsers();
        }

        private void cbSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSorting.SelectedIndex.Equals(0))
            {
                LoadCountries(false);
            }
            else if (cbSorting.SelectedIndex.Equals(1))
            {
                LoadCountries(true);
            }
        }

        private void btnEditBrowsers_Click(object sender, EventArgs e)
        {
            string filename = strAppDir + "\\config\\browsers.config";
            if (!File.Exists(filename))
            {
                string temp = "Browser Name,Target,Arguments";
                File.WriteAllText(filename, temp);
            }
            try
            {
                FrmEditConfig frmEditConfig = new FrmEditConfig();
                frmEditConfig.Text = "Edit Browser Configuration";
                frmEditConfig.storeFileName(filename);
                frmEditConfig.createColumns();
                frmEditConfig.loadData();
                frmEditConfig.ShowDialog();
                cbBrowser.ResetText();
                cbBrowser.SelectedIndex = -1;
                LoadBrowsers();
                ShowDefaultView();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: cannot load parameters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditStores_Click(object sender, EventArgs e)
        {
            string filename = strAppDir + "\\config\\stores.config";
            if (!File.Exists(filename))
            {
                string temp = "ONLINE url,Store Name";
                File.WriteAllText(filename, temp);
            }
            try
            {
                FrmEditConfig frmEditConfig = new FrmEditConfig();
                frmEditConfig.Text = "Edit Store Configuration";
                frmEditConfig.storeFileName(strAppDir + "\\config\\stores.config");
                frmEditConfig.createColumns();
                frmEditConfig.loadData();
                frmEditConfig.ShowDialog();
                cbStore.ResetText();
                cbStore.SelectedIndex = -1;
                LoadStores();
                ShowDefaultView();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: cannot load parameters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditEnvironments_Click(object sender, EventArgs e)
        {
            string filename = strAppDir + "\\config\\environments.config";
            if (!File.Exists(filename))
            {
                string temp = "Environment";
                File.WriteAllText(filename, temp);
            }
            try
            {
                FrmEditConfig frmEditConfig = new FrmEditConfig();
                frmEditConfig.Text = "Edit Environment Configuration";
                frmEditConfig.storeFileName(filename);
                frmEditConfig.createColumns();
                frmEditConfig.loadData();
                frmEditConfig.ShowDialog();
                cbEnvironment.ResetText();
                cbStore.SelectedIndex = -1;
                LoadEnvironments();
                ShowDefaultView();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: cannot load parameters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditCountries_Click(object sender, EventArgs e)
        {
            string filename = strAppDir + "\\config\\countries.config";
            if (!File.Exists(filename))
            {
                string temp = "Country";
                File.WriteAllText(filename, temp);
            }
            try
            {
                FrmEditConfig frmEditConfig = new FrmEditConfig();
                frmEditConfig.Text = "Edit Country Configuration";
                frmEditConfig.storeFileName(filename);
                frmEditConfig.createColumns();
                frmEditConfig.loadData();
                frmEditConfig.ShowDialog();
                cbCountry.ResetText();
                cbStore.SelectedIndex = -1;
                LoadCountries(false);
                ShowDefaultView();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: cannot load parameters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditParameters_Click(object sender, EventArgs e)
        {
            string filename = strAppDir + "\\config\\parameters.config";
            if (!File.Exists(filename))
            {
                string temp = "Parameter";
                File.WriteAllText(filename, temp);
            }
            try
            {
                FrmEditConfig frmEditConfig = new FrmEditConfig();
                frmEditConfig.Text = "Edit Parameters Configuration";
                frmEditConfig.storeFileName(filename);
                frmEditConfig.createColumns();
                frmEditConfig.loadData();
                frmEditConfig.ShowDialog();
                cbParameters.ResetText();
                cbParameters.SelectedIndex = -1;
                LoadParameters();
                ShowDefaultView();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File \"" + filename.Substring(filename.LastIndexOf("\\") + 1) + "\" not found: cannot load parameters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadPresetMenu_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                EnableControls();
                Reload();
                LoadPreset(openFile.FileName);
            }
        }

        private void savePresetMenu_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                SavePreset(saveFile.FileName);
                LoadPresets();
            }
        }

        private void resetMenu_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            goMenu.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            Reload();
        }

        private void goMenu_Click(object sender, EventArgs e)
        {
            Launch();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            goMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter)));
            txtNewCountry.MaxLength = 2;
            saveFile.InitialDirectory = Application.StartupPath + @"\config";
            openFile.InitialDirectory = Application.StartupPath + @"\config";
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            CheckComboBox();
        }

        private void cbParameters_TextChanged(object sender, EventArgs e)
        {
            if (((SuggestComboBox)sender).Text.Equals(String.Empty))
            {
                ShowCountry();
                btnAddParameter.Enabled = false;
            }
            else
            {
                HideCountry();
                if (cbParameters.FindStringExact(cbParameters.Text) == -1) { btnAddParameter.Enabled = true; }
                else { btnAddParameter.Enabled = false; }
            }
            comboBox_TextChanged(sender, e);
        }

        private void btnPresets_Click(object sender, EventArgs e)
        {
            if (lvPresets.Visible)
            {
                HidePresets();
            }
            else
            {
                LoadPresets();
                ShowPresets();
            }
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            AddNewParameter();
        }
        
        private void lvPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPresets.SelectedItems.Count < 1)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
        }

        private void lvPresets_Click(object sender, EventArgs e)
        {
            string filpath = strAppDir + "\\config\\";
            if (lvPresets.SelectedItems.Count == 1)
            {
                btnDelete.Enabled = true;
                EnableControls();
                int count = 0;
                for (int i = count; i < lvPresets.Items.Count; i++)
                {
                    count = i;
                    if (lvPresets.Items[i].Text.Equals(lvPresets.SelectedItems[0].Text)) { break; }
                }
                LoadPreset(filpath + lvPresets.SelectedItems[0].Text + ".preset");
                lvPresets.Items[count].Selected = true;
                lvPresets.EnsureVisible(count);
            }
            else
            {
                DisableControls();
                btnDelete.Enabled = false;
            }
        }

        private void lvPresets_DoubleClick(object sender, EventArgs e)
        {
            string filepath = strAppDir + "\\config\\";
            if (lvPresets.SelectedItems.Count == 1)
            {
                int index = lvPresets.SelectedItems[0].Index;
                LoadPreset(filepath + lvPresets.Items[index].Text + ".preset");
                lvPresets.Items[index].Selected = true;
                lvPresets.EnsureVisible(index);
                Launch();
            }
        }

        private void tbPresets_TextChanged(object sender, EventArgs e)
        {
            LoadPresets(tbPresets.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbPresets.Clear();
            btnDelete.Enabled = false;
            LoadPresets();
            tbPresets.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                SavePreset(saveFile.FileName);
                LoadPresets();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string filpath = strAppDir + "\\config\\";
            if (lvPresets.SelectedItems.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + lvPresets.SelectedItems[0].Text + "\"?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(filpath + lvPresets.SelectedItems[0].Text + ".preset");
                    tbPresets.Clear();
                    btnDelete.Enabled = false;
                    LoadPresets();
                }
            }
        }

        private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }
    }
}
