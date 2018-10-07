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
    public partial class Form4 : Form
    {
        private static string step = "";
        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static string Step { get => step; set => step = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            step = textBox1.Text;
            this.Close();
        }
    }
}
