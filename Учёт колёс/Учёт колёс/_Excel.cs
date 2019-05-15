using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Учёт_колёс
{
    internal class _Excel
    {
        private Excel.Application ExcelApp;
        private Excel.Workbook workbook;
        private Excel.Workbook workbookTemplate;
        private Excel.Worksheet worksheet;
        private _Close _close = new _Close();
        private StreamReader sr;
        private StreamWriter sw;
        private int iLastRow;

        public void UploadInExcel(Excel.Application ExcelApp, DataGridView dataGridView1, SaveFileDialog saveFileDialog1)
        {
            int namber = 0;
            int namberDouble = 0;
            int vs = 0;
            int ns = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    namber = Convert.ToInt32(dataGridView1[1, i].Value.ToString());
                    namberDouble = namber;
                    if (namber <= 50)
                    {
                        vs = 2;
                        ns = 3;
                    }
                    if (namber > 50 && namber < 101)
                    {
                        namber -= 50;
                        vs = 5;
                        ns = 6;
                    }
                    if (namber > 100 && namber < 151)
                    {
                        namber -= 100;
                        vs = 8;
                        ns = 9;
                    }
                    if (namber > 150 && namber < 201)
                    {
                        namber -= 150;
                        vs = 11;
                        ns = 12;
                    }
                    if (namber > 200 && namber < 251)
                    {
                        namber -= 200;
                        vs = 14;
                        ns = 15;
                    }
                    if (namber > 250 && namber < 301)
                    {
                        namber -= 250;
                        vs = 17;
                        ns = 18;
                    }
                    if (namber > 300 && namber < 351)
                    {
                        namber -= 300;
                        vs = 20;
                        ns = 21;
                    }

                    if (dataGridView1[2, i].Value.ToString() == "В/С")
                    {
                        if (ExcelApp.Cells[namber + 3, vs].Value2 == null)
                        {
                            ExcelApp.Cells[namber + 3, vs] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                        else
                        {
                            iLastRow = worksheet.Cells[worksheet.Rows.Count, 23].End[Excel.XlDirection.xlUp].Row;                            
                            ExcelApp.Cells[iLastRow + 1, 23] = namberDouble;
                            ExcelApp.Cells[iLastRow + 1, 24] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                    }

                    if (dataGridView1[2, i].Value.ToString() == "Н/С")
                    {
                        if (ExcelApp.Cells[namber + 3, ns].Value2 == null)
                        {
                            ExcelApp.Cells[namber + 3, ns] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                        else
                        {
                            iLastRow = worksheet.Cells[worksheet.Rows.Count, 23].End[Excel.XlDirection.xlUp].Row;
                            ExcelApp.Cells[iLastRow + 1, 23] = namberDouble;
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

        public void CreateExcel(string filename, string path, SaveFileDialog saveFileDialog1)
        {
            ExcelApp = new Excel.Application();
            saveFileDialog1.Title = "Создать";
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.ShowDialog();
            filename = saveFileDialog1.FileName;
            try
            {
                if (filename != "")
                {
                    sw = new StreamWriter(path, false, Encoding.Default);
                    ExcelApp.SheetsInNewWorkbook = 1;
                    workbook = ExcelApp.Workbooks.Add();
                    workbook.SaveAs(filename);
                    filename = saveFileDialog1.FileName;
                    sw.Write(filename);
                    sw.Close();
                    ExcelApp.Quit();
                }
            }
            catch { }
            filename = "";
            saveFileDialog1.FileName = "";
        }

        public void OpenExcel(string filename, string path, OpenFileDialog openFileDialog1)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = @"D:\";
            filename = openFileDialog1.FileName;
            if (filename == "")
            {
                sr = new StreamReader(path, Encoding.Default);
                filename = sr.ReadLine();
                sr.Close();
            }
            else
            {
                filename = openFileDialog1.FileName;                
                for (int i = 0; i < filename.Length; i++)
                {
                    if (filename[i] == '.')
                    {
                        for (int j = i; j < filename.Length; j++)
                        {
                            filename = filename.Remove(i);
                        }

                    }
                }
                sw = new StreamWriter(path, false, Encoding.Default);
                sw.Write(filename);
                sw.Close();
            }
            filename = "";
            openFileDialog1.FileName = "";
        }

        public void ExportToExcel(string filename, string path, string template, TextBox textBox1, DataGridView dataGridView1, SaveFileDialog saveFileDialog1)
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
                _close.CloseProcess();
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
                _close.CloseProcess();
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
                UploadInExcel(ExcelApp, dataGridView1, saveFileDialog1);
                return;
            }
            ExcelApp.Visible = true;
            worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(worksheetname);
            worksheet.Activate();
            //Выгрузка массива в лист
            UploadInExcel(ExcelApp, dataGridView1, saveFileDialog1);
        }

        public void SearchInExcel(string filename, string path, TextBox textBox1, TextBox textBox2, RadioButton radioButton1, RadioButton radioButton2)
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
            try
            {
                worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("№ плавки " + textBox1.Text + " не найден :(");
                _close.CloseProcess();
                return;
            }
            worksheet.Activate();
            try
            {
                n = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Введите № колёса!");
                return;
            }
            
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
            _close.CloseProcess();
            GC.Collect();
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
    }
}
