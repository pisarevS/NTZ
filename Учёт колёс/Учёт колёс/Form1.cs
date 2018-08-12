using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Учёт_колёс
{
    public partial class Form1 : Form
    {
        Excel.Application ExcelApp;
        Excel.Workbook workbook;
        Excel.Workbook workbookTemplate;
        Excel.Worksheet worksheet;
        DataGridViewTextBoxCell txtxCell;
        StreamReader sr;
        StreamWriter sw;
        string filename = null;
        int namber = 1;
        string side = null;
        string path = "file.txt";
        string template = Path.GetFullPath("template.xls");
        int iLastRow;

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

        public void CloseProcess()
        {
            Process[] List;
            List = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in List)
            {
                proc.Kill();
            }
        }

        public void UploadInExcel(Excel.Application ExcelApp)
        {
            int n = 0;
            int vs = 0;
            int ns = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    n = Convert.ToInt32(dataGridView1[1, i].Value.ToString());
                    if (n <= 50)
                    {
                        vs = 2;
                        ns = 3;
                    }
                    if (n > 50 && n < 101)
                    {
                        n -= 50;
                        vs = 5;
                        ns = 6;
                    }
                    if (n > 100 && n < 151)
                    {
                        n -= 100;
                        vs = 8;
                        ns = 9;
                    }
                    if (n > 150 && n < 201)
                    {
                        n -= 150;
                        vs = 11;
                        ns = 12;
                    }
                    if (n > 200 && n < 251)
                    {
                        n -= 200;
                        vs = 14;
                        ns = 15;
                    }
                    if (n > 250 && n < 301)
                    {
                        n -= 250;
                        vs = 17;
                        ns = 18;
                    }
                    if (n > 300 && n < 351)
                    {
                        n -= 300;
                        vs = 20;
                        ns = 21;
                    }

                    if (dataGridView1[2, i].Value.ToString() == "В/С")
                    {
                        if (ExcelApp.Cells[n + 3, vs].Value2 == null)
                        {
                            ExcelApp.Cells[n + 3, vs] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                        else
                        {
                            iLastRow = worksheet.Cells[worksheet.Rows.Count, 23].End[Excel.XlDirection.xlUp].Row;
                            ExcelApp.Cells[iLastRow + 1, 23] = n;
                            ExcelApp.Cells[iLastRow + 1, 24] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                    }

                    if (dataGridView1[2, i].Value.ToString() == "Н/С")
                    {
                        if (ExcelApp.Cells[n + 3, ns].Value2 == null)
                        {
                            ExcelApp.Cells[n + 3, ns] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                        else
                        {
                            iLastRow = worksheet.Cells[worksheet.Rows.Count, 23].End[Excel.XlDirection.xlUp].Row;
                            ExcelApp.Cells[iLastRow + 1, 23] = n;
                            ExcelApp.Cells[iLastRow + 1, 25] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                    }
                }
            }
            catch
            {
                try
                {
                    ExcelApp.ActiveWorkbook.ActiveSheet(saveFileDialog1.FileName.ToString());
                    ExcelApp.ActiveWorkbook.ActiveSheet.Saved = true;
                    ExcelApp.Quit();
                    GC.Collect();
                }
                catch
                {
                    ExcelApp.Quit();
                    GC.Collect();
                }
            }

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
            sw = new StreamWriter(path, false, Encoding.Default);
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Книга Excel 97-2003 |*.xls";
            filename = openFileDialog1.FileName;
            sw.Write(filename);
            sw.Close();
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
            sr.Close();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter(path, false, Encoding.Default);
            ExcelApp = new Excel.Application();
            saveFileDialog1.Title = "Создать";
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Filter = "Книга Excel 97-2003 |*.xls";
            saveFileDialog1.ShowDialog();
            ExcelApp.SheetsInNewWorkbook = 1;
            workbook = ExcelApp.Workbooks.Add();
            try
            {
                workbook.SaveAs(saveFileDialog1.FileName);
            }
            catch { }
            filename = saveFileDialog1.FileName;
            sw.Write(filename);
            sw.Close();
            sr = new StreamReader(path, Encoding.Default);
            Text = sr.ReadLine();
            sr.Close();
            ExcelApp.Quit();
        }

        public static bool ShExist(object workbook, string worksheetname)
        {
            bool bEx = false;
            object wsPShts = null, wsSh = null;
            wsPShts = workbook.GetType().InvokeMember("Worksheets", System.Reflection.BindingFlags.GetProperty, null, workbook, null);
            try
            {
                wsSh = wsPShts.GetType().InvokeMember("Item", System.Reflection.BindingFlags.GetProperty, null, wsPShts, new object[] { worksheetname });
                bEx = true;
            }
            catch { bEx = false; }
            return (bEx);
        }

        public void ExportToExcel(string filename)
        {
            string worksheetname = textBox1.Text;
            sr = new StreamReader(path, Encoding.Default);
            filename = sr.ReadLine();
            sr.Close();
            ExcelApp = new Excel.Application();
            try
            {
                workbook = ExcelApp.Workbooks.Open(filename);
            }
            catch
            {
                ExcelApp.Quit();
                GC.Collect();
                CloseProcess();
                MessageBox.Show("Файл не найден :(");
                return;
            }
            try
            {
                workbookTemplate = ExcelApp.Workbooks.Open(template);
            }
            catch
            {
                ExcelApp.Quit();
                GC.Collect();
                CloseProcess();
                MessageBox.Show("Файл шаблона не найден :(");
                return;
            }

            ExcelApp.Visible = false;
            worksheet = null;
            int sheetscount = workbook.Sheets.Count;
            if (ShExist(workbook, worksheetname) == false)
            {//Создаем лист, если лист с таким именем отсутствует
                try
                {
                    ExcelApp.Visible = false;
                    worksheet = (Excel.Worksheet)workbookTemplate.Sheets[1];
                    worksheet.Name = worksheetname;
                    workbookTemplate.Save();
                    workbookTemplate.Worksheets[1].Copy(After: workbook.Worksheets[sheetscount]);
                    ExcelApp.Visible = true;
                }
                catch { }
                //Выгрузка массива в лист
                UploadInExcel(ExcelApp);
                return;
            }
            ExcelApp.Visible = true;
            worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(worksheetname);
            worksheet.Activate();
            //Выгрузка массива в лист
            UploadInExcel(ExcelApp);
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
            ExportToExcel(filename);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel(filename);
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
            int n = 0;
            int vs = 0;
            int ns = 0;
            string nameOperator = "";
            sr = new StreamReader(path, Encoding.Default);
            filename = sr.ReadLine();
            sr.Close();
            ExcelApp = new Excel.Application();
            workbook = ExcelApp.Workbooks.Open(filename);
            //ExcelApp.Visible = true;
            try
            {
                worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Плавка номер " + textBox1.Text + " не найдена :(");
                CloseProcess();
                return;
            }
            worksheet.Activate();
            n = Convert.ToInt32(textBox2.Text);
            if (n <= 50)
            {
                vs = 2;
                ns = 3;
            }
            if (n > 50 && n < 101)
            {
                n -= 50;
                vs = 5;
                ns = 6;
            }
            if (n > 100 && n < 151)
            {
                n -= 100;
                vs = 8;
                ns = 9;
            }
            if (n > 150 && n < 201)
            {
                n -= 150;
                vs = 11;
                ns = 12;
            }
            if (n > 200 && n < 251)
            {
                n -= 200;
                vs = 14;
                ns = 15;
            }
            if (n > 250 && n < 301)
            {
                n -= 250;
                vs = 17;
                ns = 18;
            }
            if (n > 300 && n < 351)
            {
                n -= 300;
                vs = 20;
                ns = 21;
            }

            if (radioButton1.Checked)
            {
                nameOperator = ExcelApp.Cells[n + 3, vs].Value2;
            }

            if (radioButton2.Checked)
            {
                nameOperator = ExcelApp.Cells[n + 3, ns].Value2;
            }
            MessageBox.Show(nameOperator);
            ExcelApp.Quit();
            CloseProcess();
            GC.Collect();
        }
    }
}
