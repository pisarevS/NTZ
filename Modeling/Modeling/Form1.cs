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
        private Point coordinateZero;

        private Point startPoint, endPoint;
        private int radius;
        private bool movable = false;
        private bool isButtonClickebl = false;
        private int mousDownX, mousDownY,mousMoveX,mousMoveY;
        private double zoomDefalt=10;
        private double zoom=1;


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
                    label1.Text = Convert.ToString(zoom*100+"%");
                    Manager();
                }
                else
                {
                    zoomDefalt--;
                    if (zoomDefalt < 1)
                        zoomDefalt = 1;
                    zoom = zoomDefalt / 10;
                    label1.Text = Convert.ToString(zoom * 100+"%");
                    Manager();
                }
            }
            

        }

        private void Manager()
        {
            drawContour = new DrawContour(pictureBox1, coordinateZero);
            drawContour.SystemСoordinate(pictureBox1, coordinateZero);

            startPoint.X = 20;
            startPoint.Z = 20;
            endPoint.X = 100;
            endPoint.Z = 100;                      
            drawContour.DrawLine(coordinateZero,zoom, startPoint, endPoint);

            startPoint.X = -20;
            startPoint.Z = -20;
            endPoint.X = -100;
            endPoint.Z = -100;
            drawContour.DrawLine(coordinateZero, zoom, startPoint, endPoint);

            startPoint.X = -20;
            startPoint.Z = 20;
            endPoint.X = -100;
            endPoint.Z = 100;
            drawContour.DrawLine(coordinateZero, zoom, startPoint, endPoint);

            startPoint.X = 20;
            startPoint.Z = -20;
            endPoint.X = 100;
            endPoint.Z = -100;
            drawContour.DrawLine(coordinateZero, zoom, startPoint, endPoint);

        }

        public void Init()
        {
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            startPoint = new Point();
            endPoint = new Point();
            drawContour = new DrawContour(pictureBox1, coordinateZero);
            drawContour.SystemСoordinate(pictureBox1, coordinateZero);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            isButtonClickebl = true;          
            Manager();
        }

        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            coordinateZero = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            drawContour = new DrawContour(pictureBox1, coordinateZero);
            drawContour.SystemСoordinate(pictureBox1, coordinateZero);
            isButtonClickebl = false;
            zoom = 1;
            label1.Text = "100%";
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
                drawContour = new DrawContour(pictureBox1, coordinateZero);
                mousMoveX = coordinateZero.X - mousDownX;
                mousMoveY = coordinateZero.Z - mousDownY;             
                coordinateZero.X = Convert.ToInt32(e.X);
                coordinateZero.Z = Convert.ToInt32(e.Y);
                coordinateZero.X += mousMoveX;
                coordinateZero.Z += mousMoveY;
                mousDownX = Convert.ToInt32(e.X);
                mousDownY = Convert.ToInt32(e.Y);

                drawContour.SystemСoordinate(pictureBox1, coordinateZero);
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
            drawContour = new DrawContour(pictureBox1, coordinateZero);
            drawContour.SystemСoordinate(pictureBox1, coordinateZero);
            if (isButtonClickebl)
            {
                Manager();
            }
        }

    }
}
