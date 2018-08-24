using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Учёт_колёс
{
    public partial class Form1 : Form
    {
        DataGridViewTextBoxCell txtxCell;
        StreamReader sr;
        _Close _close = new _Close();
        _Excel _excel = new _Excel();
        string template = Path.GetFullPath("template.xls");
        string path = "file.txt";
        string side = null;
        int namber = 1;
        
        public Form1()
        {
            InitializeComponent();
            VS.Checked = true;
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
            sr.Close();
            openFileDialog1.FileName = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "Штат операторов.txt";
            sr = new StreamReader(path, Encoding.Default);
            while (!sr.EndOfStream)
                oper.Items.Add(sr.ReadLine());
            sr.Close();
        }

        public void EnabledButton()
        {
            if (oper.Text != "" && meltingNumber.Text != "" && wheelNumber.Text != "")
            {
                enter.Enabled = true;
            }
            else
            {
                enter.Enabled = false;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _excel.OpenExcel(path,openFileDialog1);
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _excel.CreateExcel(path,saveFileDialog1);
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
        }

        private void EnterButton(object sender, EventArgs e)
        {
            if (VS.Checked) side = "В/С";
            if (NS.Checked) side = "Н/С";
            dataGridView1.Rows.Add(Convert.ToString(namber++), wheelNumber.Text, side, oper.Text);
            wheelNumber.Text = "";
            if (dataGridView1.Rows.Count != 0)
                save.Enabled = true;
        }

        private void DeleteAllButton(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            namber = 1;
            if (dataGridView1.Rows.Count == 1)
                save.Enabled = false;
        }

        private void DeleteCellButton(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView1.SelectedCells[0].RowIndex;
                int a = dataGridView1.RowCount;
                a = a - 2;
                dataGridView1.Rows.RemoveAt(ind);
                for (int i = 0; i < a; i++)
                {
                    txtxCell = (DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells[0];
                    txtxCell.Value = Convert.ToString(i + 1);
                }
                namber = a + 1;
                if (dataGridView1.Rows.Count == 1)
                {
                    save.Enabled = false;
                }
            }
            catch { }
        }

        private void EnterButtonKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && wheelNumber.Text != "")
                EnterButton(sender, e);

            if (e.KeyCode == Keys.PageDown)
            {
                if (VS.Checked) NS.Checked = true;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                if (NS.Checked) VS.Checked = true;
            }
            if (e.KeyCode == Keys.F5 && save.Enabled == true)
                SaveButton(sender, e);

        }

        private void SaveButton(object sender, EventArgs e)
        {
            _excel.ExportToExcel(path,template, meltingNumber,dataGridView1,saveFileDialog1);
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            _excel.ExportToExcel(path,template, meltingNumber, dataGridView1,saveFileDialog1);
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            //CloseProcess();
            this.Close();
        }

        private void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            EnabledButton();
        }

        private void MeltingNumberTextChanged(object sender, EventArgs e)
        {
            EnabledButton();
        }

        private void WheelNumberTextChanged(object sender, EventArgs e)
        {
            EnabledButton();
        }

        private void SearchButton(object sender, EventArgs e)
        {
            _excel.SearchInExcel(path,meltingNumber, wheelNumber,VS,NS);
        }
    }
}
