using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Учёт_колёс
{
    class Export :Form
    {
        Excel.Application ExcelApp;
        Excel.Workbook workbook;
        Excel.Workbook workbookTemplate;
        Excel.Worksheet worksheet;
        StreamReader sr;
        StreamWriter sw;
        string path = "file.txt";
        TextBox textBox1;
        string template = Path.GetFullPath("template.xls");
        int iLastRow;
        SaveFileDialog saveFileDialog1;
        Form1 form1 = new Form1();

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
                form1.CloseProcess();
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
                form1.CloseProcess();
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
                form1.UploadInExcel(ExcelApp);
                return;
            }
            ExcelApp.Visible = true;
            worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(worksheetname);
            worksheet.Activate();
            //Выгрузка массива в лист
            form1.UploadInExcel(ExcelApp);
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
