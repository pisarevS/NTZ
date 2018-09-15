using System;
using System.Collections.Generic;
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
        private DrawContour drawContour;
        private Point point, startPoint, endPoint;
        private bool movable = false;
        private bool isButtonClicked = false;
        private int mousDownX, mousDownY,mousMoveX,mousMoveY;
        
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Manager()
        {
            drawContour.DrawArc(point);
            drawContour.DrawLine(startPoint, endPoint);
        }

        public void Init()
        {
            point = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            startPoint = new Point();
            endPoint = new Point();
            drawContour = new DrawContour(pictureBox1, point);
            drawContour.SystemСoordinate(pictureBox1, point);
            startPoint.X = 10;
            startPoint.Y = 20;
            endPoint.X = 100;
            endPoint.Y = 70;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            isButtonClicked = true;
            drawContour = new DrawContour(pictureBox1, point);
            drawContour.SystemСoordinate(pictureBox1, point);

            Manager();
        }

        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            point = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            drawContour = new DrawContour(pictureBox1, point);
            drawContour.SystemСoordinate(pictureBox1, point);
            isButtonClicked = false;
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
                drawContour = new DrawContour(pictureBox1, point);
                mousMoveX = point.X - mousDownX;
                mousMoveY = point.Y - mousDownY;             
                point.X = Convert.ToInt32(e.X);
                point.Y = Convert.ToInt32(e.Y);
                point.X += mousMoveX;
                point.Y += mousMoveY;
                mousDownX = Convert.ToInt32(e.X);
                mousDownY = Convert.ToInt32(e.Y);

                drawContour.SystemСoordinate(pictureBox1, point);
                if (isButtonClicked)
                {
                    Manager();
                }            
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            point.X = pictureBox1.Width / 2;
            point.Y = pictureBox1.Height / 2;
            drawContour = new DrawContour(pictureBox1, point);
            drawContour.SystemСoordinate(pictureBox1, point);
            if (isButtonClicked)
            {
                Manager();
            }
        }

    }
}
