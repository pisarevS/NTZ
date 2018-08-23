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
        int namber = 1;
        string side = null;
       
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
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
                comboBox1.Items.Add(sr.ReadLine());
            sr.Close();
        }

        public void EnabledButton()
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _excel.OpenExcel(path,openFileDialog1);
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _excel.CreateExcel(path,saveFileDialog1);
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) side = "В/С";
            if (radioButton2.Checked) side = "Н/С";
            dataGridView1.Rows.Add(Convert.ToString(namber++), textBox2.Text, side, comboBox1.Text);
            textBox2.Text = "";
            if (dataGridView1.Rows.Count != 0)
                button5.Enabled = true;
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            namber = 1;
            if (dataGridView1.Rows.Count == 1)
                button5.Enabled = false;
        }

        private void deleteCell_Click(object sender, EventArgs e)
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
                    button5.Enabled = false;
                }
            }
            catch { }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && textBox2.Text != "")
                button1_Click(sender, e);

            if (e.KeyCode == Keys.PageDown)
            {
                if (radioButton1.Checked) radioButton2.Checked = true;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                if (radioButton2.Checked) radioButton1.Checked = true;
            }
            if (e.KeyCode == Keys.F5 && button5.Enabled == true)
                button5_Click(sender, e);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _excel.ExportToExcel(path,template, textBox1,dataGridView1,saveFileDialog1);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _excel.ExportToExcel(path,template, textBox1, dataGridView1,saveFileDialog1);
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseProcess();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnabledButton();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnabledButton();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            EnabledButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _excel.SearchInExcel(path,textBox1, textBox2,radioButton1,radioButton2);
        }
    }
}
