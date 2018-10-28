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
    public partial class Form1 : Form
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
        public static int index = 0;
        private ReadFile readFile;

        public Form1()
        {
            InitializeComponent();
            Init();
            pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isButtonClickebl)
            {
                if (e.Delta > 0)
                {
                    zoomDefalt++;
                    if (zoomDefalt > 30)
                        zoomDefalt = 30;
                    zoom = zoomDefalt / 10;
                    label1.Text = Convert.ToString(zoom * 100 + "%");
                    Manager();
                }
                else
                {
                    zoomDefalt--;
                    if (zoomDefalt < 5)
                        zoomDefalt = 5;
                    zoom = zoomDefalt / 10;
                    label1.Text = Convert.ToString(zoom * 100 + "%");
                    Manager();
                }
            }
        }

        private void Manager()
        {
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            draw.DrawСontour(coordinateZero, zoom);
        }

        public void Init()
        {
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            startPoint = new Point();
            endPoint = new Point();
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            readFile = new ReadFile();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
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
                buttonStart.Enabled = false;
                index = richTextBox1.Lines.Length;
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
        }

        public void ButtonReset_Click(object sender, EventArgs e)
        {
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
            buttonSingleBlock.Enabled = true;
            index = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.ScrollToCaret();
            N.Text = "N";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Lines.Length != 0)
            {
                buttonStart.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = false;
            }
        }

        private void AboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.Show();
        }

        private void FindAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Owner = this;
            form3.ShowDialog();
            FindAndReplace();
        }

        private void RenumberFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
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
            isButtonPauce = true;
            buttonSingleBlock.Enabled = false;
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
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                myCollection.Add(richTextBox2.Lines[i], MyCollection.ListParameter);
            }
            myCollection.ReadParametrVariables(); ;
            for (int i = 0; i < index; i++)
            {
                myCollection.Add(richTextBox1.Lines[i], MyCollection.ListCadrs);
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
                zoomDefalt++;
                if (zoomDefalt > 30)
                    zoomDefalt = 30;
                zoom = zoomDefalt / 10;
                label1.Text = Convert.ToString(zoom * 100 + "%");
                Manager();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isButtonClickebl)
            {
                zoomDefalt--;
                if (zoomDefalt < 5)
                    zoomDefalt = 5;
                zoom = zoomDefalt / 10;
                label1.Text = Convert.ToString(zoom * 100 + "%");
                Manager();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                labelX.Text = "X " + Math.Round(x).ToString();
                labelZ.Text = "Z " + Math.Round(Math.Abs(z)).ToString();
                return;
            }
            labelX.Text = "X " + Math.Round(x).ToString();
            labelZ.Text = "Z " + Math.Round(z).ToString();
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

        private void FindAndReplace()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                if (richTextBox1.Lines[i].Contains(Form3.Find))
                {
                    try
                    {
                        string s = richTextBox1.Lines[i].Replace(Form3.Find, Form3.Replace);
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
                        string g = (int.Parse(Form4.Step) * (t)).ToString() + " ";
                        list[i] = null;
                        list[i] = "N" + g + d;
                        d = null;
                        str = null;
                        t++;
                    }
                    else
                    {
                        string g = (int.Parse(Form4.Step) * (t)).ToString() + "  ";
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
    }
}
