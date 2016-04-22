using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrowserLauncher
{
    public partial class FrmEditConfig : Form
    {
        private string currentFileName {get; set; }

        public FrmEditConfig()
        {
            InitializeComponent();
        }

        public void storeFileName(string fileName)
        {
            currentFileName = fileName;
        }

        public void createColumns()
        {
            string[] columns = File.ReadAllLines(currentFileName)[0].Split(',');
            if(columns.Length > 0)
            {
                this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                this.Column1.HeaderText = columns[0];
                this.Column1.Name = columns[0];
                if (columns.Length == 1)
                {
                    this.dgConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                        this.Column1});
                }
            }
            if (columns.Length > 1)
            {
                this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                this.Column2.HeaderText = columns[1];
                this.Column2.Name = columns[1];
                if (columns.Length == 2)
                {
                    this.dgConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                        this.Column1,
                        this.Column2});
                }
            }
            if (columns.Length == 3)
            {
                this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                this.Column3.HeaderText = columns[2];
                this.Column3.Name = columns[2];
                this.dgConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                    this.Column1,
                    this.Column2,
                    this.Column3});
            }
        }

        public void loadData()
        {
            string[] data = File.ReadAllLines(currentFileName);
            int count = 0;
            foreach (string line in data)
            {
                if (count > 0)
                {
                    string[] tokens = line.Split(',');
                    if (tokens.Length > 0)
                    {
                        dgConfig.Rows[count - 1].Cells[0].Value = tokens[0];
                    }
                    if (tokens.Length > 1)
                    {
                        dgConfig.Rows[count - 1].Cells[1].Value = tokens[1];
                    }
                    if (tokens.Length > 2)
                    {
                        dgConfig.Rows[count - 1].Cells[2].Value = tokens[2];
                    }
                }
                count++;
                if (count < data.Length)
                {
                    dgConfig.Rows.Add();
                }
            }
        }

        public void saveData()
        {
            List<string> fileContent = new List<string>();
            int count = 0;
            string columns = string.Empty;
            foreach (DataGridViewColumn column in dgConfig.Columns)
            {
                columns += column.Name + ",";
            }
            columns = columns.Remove(columns.Length - 1);
            fileContent.Add(columns);
            foreach (DataGridViewRow row in dgConfig.Rows)
            {
                string tempRow = string.Empty;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (!cell.Value.Equals(string.Empty))
                        {
                            tempRow += cell.Value + ",";
                        }
                    }
                }
                if (!tempRow.Equals(String.Empty))
                {
                    tempRow = tempRow.Remove(tempRow.Length - 1);
                    count++;
                    fileContent.Add(tempRow);
                }
            }
            File.WriteAllLines(currentFileName, fileContent.ToArray());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dgConfig.Rows.Clear();
            dgConfig.Columns.Clear();
            createColumns();
            loadData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.saveData();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmEditConfig_Load(object sender, EventArgs e)
        {
            dgConfig.Focus();
        }

        private void FrmEditConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
