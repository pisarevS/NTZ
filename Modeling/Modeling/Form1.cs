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
        private int mousDownX, mousDownY, mousMoveX, mousMoveY;
        private double zoomDefalt = 10;
        private double zoom = 1;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
            Init();
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isButtonClickebl)
            {
                if (e.Delta > 0)
                {
                    zoomDefalt++;
                    if (zoomDefalt > 20)
                        zoomDefalt = 20;
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
            myCollection = new MyCollection();
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                myCollection.Add(richTextBox1.Lines[i]);
            }
            myCollection.ReplaceVariables();                      
            draw.DrawСontour(coordinateZero, zoom);                         
        }

        public void Init()
        {
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            startPoint = new Point();
            endPoint = new Point();
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            isButtonClickebl = true;

            Manager();
        }

        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            draw = new Draw(pictureBox1, coordinateZero);
            draw.SystemСoordinate(pictureBox1, coordinateZero);
            isButtonClickebl = false;
            zoom = 1;
            label1.Text = "100%";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movable = true;
            mousDownX = Convert.ToInt32(e.X);
            mousDownY = Convert.ToInt32(e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            movable = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
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

    }
}
