using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modeling
{
    public partial class ModelingForm : Form
    {
        private Draw draw;
        private MyCollection myCollection;
        private Point coordinateZero;
        private Point startPoint, endPoint;
        private bool movable = false;
        private bool isButtonSysleStartClickebl = false;
        private bool isButtonStartClickebl = false;
        private bool isButtonSingleBlockClickebl = false;
        private float mousDownX, mousDownY, mousMoveX, mousMoveY;
        private float zoomDefalt = 10;
        private float zoom = 1F;
        private float x;
        private float z;       
        public static int index = 1;
        private ReadFile readFile;
        private string[] fileName1;
        private string fileNameProgram;
        private string textProgram = "";
        public static bool isError = true;
        private int numberLine=0;

        public ModelingForm()
        {
            InitializeComponent();
            Init();
            pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);
            this.StartPosition = FormStartPosition.CenterScreen;

            richTextBox1.DragEnter += RichTextBox1_DragEnter;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
            richTextBox1.AllowDrop = true;
            richTextBox1.EnableAutoDragDrop = true;

            richTextBox2.DragEnter += RichTextBox2_DragEnter;
            richTextBox2.DragDrop += RichTextBox2_DragDrop;
            richTextBox2.AllowDrop = true;
            richTextBox2.EnableAutoDragDrop = true;
        }

        public void Init()
        {
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            startPoint = new Point();
            endPoint = new Point();
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            readFile = new ReadFile();
            buttonSingleBlock.Enabled = false;
            buttonSingleBlock.BackColor = DefaultBackColor;
        }

        private void Manager()
        {
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            draw.DrawСontour(coordinateZero, zoom,numberLine);
        }

        private void ButtonSysleStart_Click(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = true;
            timer1.Interval = 100;
            isButtonSysleStartClickebl = true;
            myCollection = new MyCollection();
            myCollection.ListVariables.Clear();
            MyCollection.ListCadrs.Clear();
            MyCollection.ListParameter.Clear();       
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                myCollection.Add(richTextBox2.Lines[i], MyCollection.ListParameter);
            }
            myCollection.ReadParametrVariables();
            if (isButtonSingleBlockClickebl)
            {
                if (index < richTextBox1.Lines.Length)
                {
                    index++;
                    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(index - 1), richTextBox1.Lines[index - 1].Length);
                    richTextBox1.SelectionColor = Color.DarkBlue;
                    richTextBox1.ScrollToCaret();
                }
                else
                {
                    index = richTextBox1.Lines.Length;
                }
                buttonSysleStart.Enabled = true;
            }
            else
            {
                timer1.Enabled = true;
                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(index - 1), richTextBox1.Lines[index - 1].Length);
                richTextBox1.SelectionColor = Color.DarkBlue;
                richTextBox1.ScrollToCaret();
            }
            string cadr = "";
            for (int i = 0; i < index; i++)
            {
                cadr = richTextBox1.Lines[i];
                for (int l = 0; l < ReadFile.Ignor.Count; l++)
                {
                    if (cadr.Contains(ReadFile.Ignor[l]))
                    {
                        string s = cadr.Replace(ReadFile.Ignor[l], "");
                        cadr = null;
                        cadr = s;
                        break;
                    }
                }
                myCollection.Add(cadr, MyCollection.ListCadrs);
                cadr = "";
            }
            myCollection.ReadProgramVariables();

            Manager();

            N.Text = MyCollection.ListCadrs[index - 1];
            coorX.Text = "X " + Draw.endPoint.X.ToString();
            coorZ.Text = "Z " + Draw.endPoint.Z.ToString();
            if (index == richTextBox1.Lines.Length)
            {
                timer1.Enabled = false;
                buttonSysleStart.Enabled = true;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {       
            isButtonStartClickebl = true;
            buttonStart.Enabled = false;
            myCollection = new MyCollection();
            myCollection.ListVariables.Clear();
            MyCollection.ListCadrs.Clear();
            MyCollection.ListParameter.Clear();
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                myCollection.Add(richTextBox2.Lines[i], MyCollection.ListParameter);
            }
            myCollection.ReadParametrVariables();

            string cadr = "";
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                cadr = richTextBox1.Lines[i];
                for (int l = 0; l < ReadFile.Ignor.Count; l++)
                {
                    if (cadr.Contains(ReadFile.Ignor[l]))
                    {
                        string s = cadr.Replace(ReadFile.Ignor[l], "");
                        cadr = null;
                        cadr = s;
                        break;
                    }
                }
                myCollection.Add(cadr, MyCollection.ListCadrs);
                cadr = "";
            }
            myCollection.ReadProgramVariables();
            Manager();
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = 0;

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            isButtonStartClickebl = false;
            timer1.Enabled = false;
            buttonRefresh.Enabled = false;
            buttonStart.Enabled = true;
            MyCollection.ErrorList.Clear();
            if (richTextBox1.Lines.Length != 0)
            {
                buttonSysleStart.Enabled = true;
            }
            else
            {
                buttonSysleStart.Enabled = false;
            }

            myCollection = new MyCollection();
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            isButtonSysleStartClickebl = false;
            zoom = 1F;
            label1.Text = "100%";
            isButtonSingleBlockClickebl = false;
            buttonSingleBlock.ForeColor = Color.Black;
            index = 1;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.ScrollToCaret();
            N.Text = "N";
            coorX.Text = "X ";
            coorZ.Text = "Z ";
            numberLine = 0;
        }

        private void ButtonSingleBlock_Click(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = true;

            if (isButtonSingleBlockClickebl == true)
            {
                isButtonSingleBlockClickebl = false;
                timer1.Enabled = true;
                buttonSingleBlock.ForeColor = Color.Black;
            }
            else
            {
                isButtonSingleBlockClickebl = true;
                timer1.Enabled = false;
                buttonSingleBlock.ForeColor = Color.Green;
            }
            richTextBox1.ScrollToCaret();
            richTextBox1.Select(0, 0);
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            myCollection.ListVariables.Clear();
            MyCollection.ListCadrs.Clear();
            MyCollection.ListParameter.Clear();
            if (index > richTextBox1.Lines.Length - 1)
            {
                index = richTextBox1.Lines.Length - 1;
            }
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                myCollection.Add(richTextBox2.Lines[i], MyCollection.ListParameter);
            }
            myCollection.ReadParametrVariables();

            string cadr = "";
            for (int i = 0; i < index; i++)
            {
                cadr = richTextBox1.Lines[i];
                for (int l = 0; l < ReadFile.Ignor.Count; l++)
                {
                    if (cadr.Contains(ReadFile.Ignor[l]))
                    {
                        string s = cadr.Replace(ReadFile.Ignor[l], "");
                        cadr = null;
                        cadr = s;
                        break;
                    }
                }
                myCollection.Add(cadr, MyCollection.ListCadrs);
                cadr = "";
            }
            richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(index - 1), richTextBox1.Lines[index - 1].Length);
            richTextBox1.SelectionColor = Color.DarkBlue;

            myCollection.ReadProgramVariables();

            Manager();

            N.Text = MyCollection.ListCadrs[index - 1];
            coorX.Text = "X " + Draw.endPoint.X.ToString();
            coorZ.Text = "Z " + Draw.endPoint.Z.ToString();
        }

        private void ButtonPluse_Click(object sender, EventArgs e)
        {
            if (isButtonSysleStartClickebl || isButtonStartClickebl)
            {
                ZoomUpsizer();
            }
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (isButtonSysleStartClickebl || isButtonStartClickebl)
            {
                ZoomDownsizer();
            }
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isButtonSysleStartClickebl || isButtonStartClickebl)
            {
                if (e.Delta > 0)
                {
                    ZoomUpsizer();
                }
                else
                {
                    ZoomDownsizer();
                }
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movable = true;
            mousDownX = Convert.ToInt32(e.X);
            mousDownY = Convert.ToInt32(e.Y);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            movable = false;
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            labelX.Text = labelX.Text.Replace(" ", "=");
            labelZ.Text = labelZ.Text.Replace(" ", "=");
            Clipboard.SetText(labelX.Text + " " + labelZ.Text, TextDataFormat.UnicodeText);
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (movable)
            {
                draw = new Draw(pictureBox1, coordinateZero);
                mousMoveX = coordinateZero.X - mousDownX;
                mousMoveY = coordinateZero.Z - mousDownY;
                coordinateZero.X = Convert.ToInt32(e.X);
                coordinateZero.Z = Convert.ToInt32(e.Y);
                coordinateZero.X += mousMoveX;
                coordinateZero.Z += mousMoveY;
                mousDownX = Convert.ToInt32(e.X);
                mousDownY = Convert.ToInt32(e.Y);

                draw.SystemСoordinate(pictureBox1, coordinateZero);
                if (isButtonSysleStartClickebl || isButtonStartClickebl)
                {
                    Manager();
                }
            }
            x = (float)(e.X) - coordinateZero.X;
            z = (float)(e.Y) - coordinateZero.Z;
            x /= zoom;
            z /= zoom;
            if (z > 0) z = -z;
            else
            {
                labelX.Text = "X " + Math.Round(x, 3).ToString();
                labelZ.Text = "Z " + Math.Round(Math.Abs(z), 3).ToString();
                return;
            }
            labelX.Text = "X " + Math.Round(x, 3).ToString();
            labelZ.Text = "Z " + Math.Round(z, 3).ToString();
        }

        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            coordinateZero.X = pictureBox1.Width / 2;
            coordinateZero.Z = pictureBox1.Height / 2;
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            if (isButtonSysleStartClickebl||isButtonStartClickebl)
            {
                Manager();
            }
        }

        private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            fileName1 = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileName1 != null)
            {
                richTextBox1.LoadFile(fileName1[0], RichTextBoxStreamType.PlainText);
                fileNameProgram = fileName1[0];
                Text = fileNameProgram;
                textProgram = richTextBox1.Text;
            }
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                richTextBox1.SelectedText = e.Data.GetData(DataFormats.Text).ToString();

            }
            catch { }
            finally
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void RichTextBox2_DragEnter(object sender, DragEventArgs e)
        {
            fileName1 = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileName1 != null)
            {
                richTextBox2.LoadFile(fileName1[0], RichTextBoxStreamType.PlainText);

            }
        }

        private void RichTextBox2_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                richTextBox1.SelectedText = e.Data.GetData(DataFormats.Text).ToString();
            }
            catch { }
            finally
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Lines.Length != 0 || timer1.Enabled == false)
            {
                buttonSysleStart.Enabled = true;
                buttonSingleBlock.Enabled = true;
                buttonReset.Enabled = true;
            }

            if (richTextBox1.Lines.Length == 0)
            {
                buttonSysleStart.Enabled = false;
                buttonSingleBlock.Enabled = false;
                buttonReset.Enabled = false;
                buttonRefresh.Enabled = false;
                coorX.Text = "X ";
                coorZ.Text = "Z ";
                ButtonReset_Click(sender, e);
            }
            if (isButtonStartClickebl)
            {
                myCollection = new MyCollection();
                myCollection.ListVariables.Clear();
                MyCollection.ListCadrs.Clear();
                MyCollection.ListParameter.Clear();
                for (int i = 0; i < richTextBox2.Lines.Length; i++)
                {
                    myCollection.Add(richTextBox2.Lines[i], MyCollection.ListParameter);
                }
                myCollection.ReadParametrVariables();

                string cadr = "";
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    cadr = richTextBox1.Lines[i];
                    for (int l = 0; l < ReadFile.Ignor.Count; l++)
                    {
                        if (cadr.Contains(ReadFile.Ignor[l]))
                        {
                            string s = cadr.Replace(ReadFile.Ignor[l], "");
                            cadr = null;
                            cadr = s;
                            break;
                        }
                    }
                    myCollection.Add(cadr, MyCollection.ListCadrs);
                    cadr = "";
                }
                myCollection.ReadProgramVariables();
                Manager();                       
            }
        }

        private void ProgramOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = "*.txt";
            openFileDialog1.InitialDirectory = @"D:\";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                fileNameProgram = openFileDialog1.FileName;
                Text = fileNameProgram;
                textProgram = richTextBox1.Text;
            }
        }

        private void ParameterOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = "*.txt";
            openFileDialog1.InitialDirectory = @"D:\";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                richTextBox2.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void ProgramSaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "|*.MPF||*.SPF||*.*";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void ParameterSaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "|*.MPF||*.SPF||*.*";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void AboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTheProgram form2 = new AboutTheProgram();
            form2.Owner = this;
            form2.Show();
        }

        private void FindAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindAndReplace form3 = new FindAndReplace();
            form3.Owner = this;
            form3.ShowDialog();
            FindAndReplace();
        }

        private void RenumberFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenumberFrames form4 = new RenumberFrames();
            form4.Owner = this;
            form4.ShowDialog();
            ReplaceStep();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                       
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (index < richTextBox1.Lines.Length)
            {
                index++;
            }
            else
            {
                index = richTextBox1.Lines.Length;
            }
            ButtonSysleStart_Click(sender, e);
        }
             
        private void ModelingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string ttt = richTextBox1.Text;
            if (richTextBox1.Text != textProgram)
            {
                saveFileDialog1.FileName = fileNameProgram;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && fileNameProgram != " ")
                {
                    richTextBox1.SaveFile(fileNameProgram, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void FindAndReplace()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                if (richTextBox1.Lines[i].Contains(Modeling.FindAndReplace.Find))
                {
                    try
                    {
                        string s = richTextBox1.Lines[i].Replace(Modeling.FindAndReplace.Find, Modeling.FindAndReplace.Replace);
                        list.Add(s);
                    }
                    catch { }
                }
                else
                {
                    list.Add(richTextBox1.Lines[i]);
                }
            }
            richTextBox1.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    richTextBox1.AppendText(list[i]);
                }
                else
                {
                    richTextBox1.AppendText("\n" + list[i]);
                }
            }
            list.Clear();
        }

        private void ReplaceStep()
        {
            int t = 1;
            string str = "";
            List<string> list = new List<string>();
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                list.Add(richTextBox1.Lines[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                string cadr = list[i];
                if (cadr != "")
                {
                    if (cadr[getIndexChar(cadr)]=='N')
                    {
                        int n = getIndexChar(cadr);
                        for (int j = n + 1; j < cadr.Length; j++)
                        {
                            if (Check.isDigit(cadr[j]))
                            {
                                str += cadr[j];
                            }
                            else { break; }
                        }
                        string d = cadr.Replace("N" + str, "");
                        string g = (int.Parse(RenumberFrames.Step) * (t)).ToString() + "";
                        list[i] = null;
                        list[i] = "N" + g + d;
                        d = null;
                        str = null;
                        t++;
                    }
                    else if(cadr[getIndexChar(cadr)]!=';')
                    {
                        string g = (int.Parse(RenumberFrames.Step) * (t)).ToString() + " ";
                        list[i] = null;
                        list[i] = "N" + g + cadr;
                        t++;
                    }
                    cadr = null;
                }
            }
            richTextBox1.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    richTextBox1.AppendText(list[i]);
                }
                else
                {
                    richTextBox1.AppendText("\n" + list[i]);
                }
            }
            list.Clear();
        }

        private int getIndexChar(string cadre)
        {
            for (int i = 0; i < cadre.Length; i++)
            {
                if (cadre[i] != ' ')
                {
                    return i;
                }
            }
            return 0;
        }

        private void ZoomDownsizer()
        {
            zoomDefalt = zoomDefalt - 5; ;
            if (zoomDefalt < 5)
                zoomDefalt = 5;
            zoom = zoomDefalt / 10;
            label1.Text = Convert.ToString(Math.Round(zoom * 100) + "%");
            Manager();
        }

        private void ZoomUpsizer()
        {
            zoomDefalt = zoomDefalt + 5;
            if (zoomDefalt > 1000)
                zoomDefalt = 1000;
            zoom = zoomDefalt / 10;
            label1.Text = Convert.ToString(Math.Round(zoom * 100) + "%");
            Manager();
        }

        private void checkBoxShowError_Click(object sender, EventArgs e)
        {
            if (checkBoxShowError.Checked)
            {
                isError = true;
                MyCollection.ErrorList.Clear();
            }
            if(!checkBoxShowError.Checked)
            {
                isError = false;
            }
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            numberLine=richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());
            Manager();
            
        }
    }
}
