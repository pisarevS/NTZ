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
        private bool isButtonClickebl = false;
        private float mousDownX, mousDownY, mousMoveX, mousMoveY;
        private float zoomDefalt = 10;
        private float zoom = 1;
        private float x;
        private float z;
        private bool isButtonPauce = false;
        public static int index = 1;
        private ReadFile readFile;
        private string[] fileName1;

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
            draw.DrawСontour(coordinateZero, zoom);
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isButtonClickebl)
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

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(numericUpDown1.Value.ToString());
            isButtonClickebl = true;
            myCollection = new MyCollection();
            myCollection.ListVariables.Clear();
            MyCollection.ListCadrs.Clear();
            MyCollection.ListParameter.Clear();
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                myCollection.Add(richTextBox2.Lines[i], MyCollection.ListParameter);
            }
            myCollection.ReadParametrVariables();
            if (isButtonPauce)
            {
                if (index < richTextBox1.Lines.Length)
                {
                    index++;
                    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(index - 1), richTextBox1.Lines[index - 1].Length);
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.ScrollToCaret();
                }
                else
                {
                    index = richTextBox1.Lines.Length;
                }
                buttonStart.Enabled = true;
            }
            else
            {
                timer1.Enabled = true;
                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(index - 1), richTextBox1.Lines[index - 1].Length);
                richTextBox1.SelectionColor = Color.Blue;
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
                buttonStart.Enabled = true;
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            buttonRefresh.Enabled = false;
            if (richTextBox1.Lines.Length != 0)
            {
                buttonStart.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = false;
            }

            myCollection = new MyCollection();
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            isButtonClickebl = false;
            zoom = 1;
            label1.Text = "100%";
            isButtonPauce = false;
            buttonSingleBlock.ForeColor = Color.Black;
            index = 1;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.ScrollToCaret();
            N.Text = "N";
            coorX.Text = "X ";
            coorZ.Text = "Z ";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Lines.Length != 0 || timer1.Enabled == false)
            {
                buttonStart.Enabled = true;
                buttonSingleBlock.Enabled = true;
                buttonReset.Enabled = true;
            }

            if (richTextBox1.Lines.Length == 0)
            {
                buttonStart.Enabled = false;
                buttonSingleBlock.Enabled = false;
                buttonReset.Enabled = false;
                buttonRefresh.Enabled = false;
                coorX.Text = "X ";
                coorZ.Text = "Z ";
                ButtonReset_Click(sender, e);
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

        private void ButtonSingleBlock_Click(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = true;

            if (isButtonPauce == true)
            {
                isButtonPauce = false;
                timer1.Enabled = true;
                buttonSingleBlock.ForeColor = Color.Black;
            }
            else
            {
                isButtonPauce = true;
                timer1.Enabled = false;
                buttonSingleBlock.ForeColor = Color.Green;
            }
            richTextBox1.ScrollToCaret();
            richTextBox1.Select(0, 0);
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
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            for (int i = 0; i < index; i++)
            {
                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(i), richTextBox1.Lines[i].Length);
                richTextBox1.SelectionColor = Color.Blue;
            }

            myCollection.ReadProgramVariables();

            Manager();

            N.Text = MyCollection.ListCadrs[index - 1];
            coorX.Text = "X " + Draw.endPoint.X.ToString();
            coorZ.Text = "Z " + Draw.endPoint.Z.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isButtonClickebl)
            {
                ZoomUpsizer();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isButtonClickebl)
            {
                ZoomDownsizer();
            }
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (index < richTextBox1.Lines.Length)
            {
                index++;
            }
            else
            {
                index = richTextBox1.Lines.Length;
            }
            ButtonStart_Click(sender, e);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
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
                if (isButtonClickebl)
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
            if (isButtonClickebl)
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
            }
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            richTextBox1.SelectedText = e.Data.GetData(DataFormats.Text).ToString();
            e.Effect = DragDropEffects.None;
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
            richTextBox1.SelectedText = e.Data.GetData(DataFormats.Text).ToString();
            e.Effect = DragDropEffects.None;
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
                    if (cadr.Contains("N"))
                    {
                        int n = cadr.IndexOf("N");
                        for (int j = n + 1; j < cadr.Length; j++)
                        {
                            if (Check.ReadUp(cadr[j]))
                            {
                                str += cadr[j];
                            }
                            else { break; }
                        }
                        string d = cadr.Replace("N" + str, "");
                        string g = (int.Parse(RenumberFrames.Step) * (t)).ToString() + " ";
                        list[i] = null;
                        list[i] = "N" + g + d;
                        d = null;
                        str = null;
                        t++;
                    }
                    else
                    {
                        string g = (int.Parse(RenumberFrames.Step) * (t)).ToString() + "  ";
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

        private void ZoomDownsizer()
        {
            zoomDefalt--;
            if (zoomDefalt < 5)
                zoomDefalt = 5;
            zoom = zoomDefalt / 10;
            label1.Text = Convert.ToString(Math.Round(zoom * 100) + "%");
            Manager();
        }

        private void ZoomUpsizer()
        {
            zoomDefalt++;
            if (zoomDefalt > 100)
                zoomDefalt = 100;
            zoom = zoomDefalt / 10;
            label1.Text = Convert.ToString(Math.Round(zoom * 100) + "%");
            Manager();
        }
    }
}
