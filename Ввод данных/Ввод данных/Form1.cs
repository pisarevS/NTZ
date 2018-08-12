using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel= Microsoft.Office.Interop.Excel;



namespace Ввод_данных
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            dateTimePicker1.Value = DateTime.Today;                       
        }

        public void ImportFromExcel()
        {
            string filename = "D:/Temp.xls";
            openFileDialog1.InitialDirectory = "D:";
            openFileDialog1.Title = "Открыть";
            openFileDialog1.FileName = "Temp";
            openFileDialog1.Filter = "EXcel Files (2003)|*.xls";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Visible = true;
                Excel.Workbook workbook = ExcelApp.Workbooks.Open(filename);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                //Подсчет  пустых рядов
                int iLastRow = worksheet.Cells[worksheet.Rows.Count, 1].End[Excel.XlDirection.xlUp].Row;
                //Выгрузка массива в Excel
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            ExcelApp.Cells[i + iLastRow + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                catch
                {
                    try
                    {
                        ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void ExportToExcel()
        {
            string filename = "D:/Temp.xls";
           /* saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Title = "Сохранить";
            saveFileDialog1.FileName = "Temp";
            saveFileDialog1.Filter = "EXcel Files (2003)|*.xls";*/


            //if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
           // {
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Visible = false;
                Excel.Workbook workbook = ExcelApp.Workbooks.Open(filename);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                //Подсчет  пустых рядов
                int iLastRow = worksheet.Cells[worksheet.Rows.Count, 1].End[Excel.XlDirection.xlUp].Row;
                //Выгрузка массива в Excel
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            ExcelApp.Cells[i + iLastRow + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                catch
                {
                    
                    
                    try
                    {
                        ExcelApp.ActiveWorkbook.ActiveSheet(saveFileDialog1.FileName.ToString());
                        ExcelApp.ActiveWorkbook.ActiveSheet.Saved = true;
                    }
                    catch
                    {                   
                        ExcelApp.Quit();                       
                    }
                }
           // }
        }

        public void ShiftSchedule(DateTime date1)
        {
            string difference = null;
            int differenceint = 0;
            DateTime date2 = new DateTime();
            date2 = DateTime.Parse(dateTimePicker1.Value.ToString("dd.MM.yyyy"));
            TimeSpan differenceDate = new TimeSpan();
            differenceDate = (date2 - date1);                            // Разница между двумя датами
            difference = differenceDate.Days.ToString();
            differenceint = Convert.ToInt32(difference);
            differenceint = Math.Abs(differenceint % 4);
            switch (differenceint)
            {
                case 0:
                    label8.Text = "День";
                    break;
                case 1:
                    label8.Text = "В ночь";
                    break;
                case 2:
                    label8.Text = "С ночи";
                    break;
                case 3:
                    label8.Text = "Выходной";
                    break;
            }
        }

        public double NotWorkingTime (string time)
        {
            double prostoy = 0;
            char h1 = time[0];
            char h2 = time[1];
            char m1 = time[3];
            char m2 = time[4];
            string hh1 = char.ToString(h1);
            string hh2 = char.ToString(h2);
            string mm1 = char.ToString(m1);
            string mm2 = char.ToString(m2);
            string hh = hh1 + hh2;
            string mm = mm1 + mm2;
            int minute = Convert.ToInt32(mm);
            string MM = "";
            string[] arrminet = { "00", "016", "033", "050", "066", "083", "10", "116", "133", "150", "166","183","20","216","233","25","266","283","30","316","333","35","366","383","40","416","433","45","466","483","50","516","533","55","566","583","60","616","633","65","666","683","70","716","733","75","766","783","80","816","833","85","86","883","90","916","933","95","966","983" };
            MM = arrminet[minute];    
            string hhmm = hh + "," + MM;
            prostoy = Convert.ToDouble(hhmm);
            return prostoy;
        }

        public double Сalculation1( double prostoy, double protoch, double procent)
        {                                  
            procent = (protoch - ((1 - prostoy / 11.5) * 17)) / ((1 - prostoy / 11.5) * 17) * 100 + 100;
            return procent;
        }
    
        public double Сalculation2( double prostoy, double protoch, double procent )
        {           
            procent = (protoch - ((1 - prostoy / 11.5) * 17)) / ((1 - prostoy / 11.5) * 17) * 100 + 100;
           
            return procent;
        }

        public double Calculation3(double procent, double protoch)
        {
            procent = (protoch - 17) / 17 * 100 + 100;
            return procent;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double protoch2 = 0;
            double norm2 = 0;
            double norma = 0;
            double protoch = 0;            
            double prostoy = 0;
            double procent = 0;          
            string oper = "";
            string stanok = "";
            string smena = "";
            string date = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            string time = dateTimePicker2.Value.ToString("HH:mm:ss");
            if (radioButton1.Checked)
                smena = "А";
            if (radioButton2.Checked)
                smena = "Б";
            if (radioButton3.Checked)
                smena = "В";
            if (radioButton4.Checked)
                smena = "Г";
                                                   
                try
                {                   
                    norma = Convert.ToDouble(textBox1.Text);
                    protoch = Convert.ToDouble(textBox2.Text);
                    //Простой и 1 сортамент
                    if (dateTimePicker2.Text != "" && textBox4.Text == "")
                    {                       
                        prostoy= NotWorkingTime(time);                                              
                        norma = Convert.ToDouble(textBox1.Text);
                        protoch = Convert.ToDouble(textBox2.Text);
                        protoch = 17 / norma * protoch;
                        procent = Сalculation1( prostoy, protoch, procent);
                        dataGridView1.Rows.Add(date, smena, label8.Text, comboBox1.Text, comboBox2.Text, time, "17", Math.Round(protoch, 2), Math.Round(procent, 2));
                    }
                    //Простой и 2 сортамент
                    if (textBox4.Text != "" && dateTimePicker2.Text != "")
                    {                       
                        prostoy = NotWorkingTime(time);
                        norm2 = Convert.ToDouble(textBox4.Text);
                        protoch2 = Convert.ToDouble(textBox5.Text);
                        protoch2 = 17 / norm2 * protoch2;
                        protoch = 17 / norma * protoch;
                        protoch = protoch + protoch2;
                        procent = Сalculation2( prostoy, protoch, procent );
                        dataGridView1.Rows.Add(date, smena, label8.Text, comboBox1.Text, comboBox2.Text, time, "17", Math.Round(protoch, 2), Math.Round(procent, 2));
                    }
                }
                // Ловим исключение если строка простой пуста и меняем на ""
                catch (Exception) when (dateTimePicker2.Text == "" && textBox1.Text != "" && textBox2.Text != "")
                {                  
                    oper = Convert.ToString(comboBox1.Text);
                    stanok = Convert.ToString(comboBox2.Text);
                    norma = Convert.ToDouble(textBox1.Text);
                    protoch = Convert.ToDouble(textBox2.Text);
                    protoch = 17 / norma * protoch;
                    procent = Calculation3(procent, protoch);
                    dataGridView1.Rows.Add(date, smena, label8.Text, comboBox1.Text, comboBox2.Text, "", "17",Math.Round( protoch,2), Math.Round(procent, 2));
                }
                // Ловим исключение если строчки простой, норма и проточено пустые
                catch
                {
                }
                dateTimePicker2.Text = "00:00:00";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";        
        }
     
        private void deleteCells_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
      
        private void сохронитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            //Form1 form1 = new Form1();
            //form1.Show();
            this.Close();
        }

        private void оПрограмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Опрограмме = new Form2();
            Опрограмме.ShowDialog();            
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateA = new DateTime();
            DateTime dateB = new DateTime();
            DateTime dateV = new DateTime();
            DateTime dateG = new DateTime();
            dateA = DateTime.Parse("01.03.2018");
            dateB = DateTime.Parse("04.03.2018");
            dateV = DateTime.Parse("02.03.2018");
            dateG = DateTime.Parse("03.03.2018");
            if (radioButton1.Checked)
            {
                ShiftSchedule(dateA);
            }
            if (radioButton2.Checked)
            {
                ShiftSchedule(dateB);
            }
            if (radioButton3.Checked)
            {
                ShiftSchedule(dateV);
            }
            if (radioButton4.Checked)
            {
                ShiftSchedule(dateG);
            }        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {           
            DateTime dateA = new DateTime();
            dateA = DateTime.Parse("01.03.2018");
            ShiftSchedule(dateA);
        }       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dateB = new DateTime();
            dateB = DateTime.Parse("04.03.2018");
            ShiftSchedule(dateB);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dateV = new DateTime();
            dateV = DateTime.Parse("02.03.2018");
            ShiftSchedule(dateV);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dateG = new DateTime();
            dateG = DateTime.Parse("03.03.2018");
            ShiftSchedule(dateG);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            if (dateTimePicker2.Text != "00:00:00")
                groupBox2.Visible = true;
            else
                groupBox2.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != ""&&(label8.Text == "В ночь"||label8.Text == "День"))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}             

     

