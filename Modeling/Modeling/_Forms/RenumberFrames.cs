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
    public partial class RenumberFrames : Form
    {
        private static string step = "";

        public static string Step
        {
            get { return RenumberFrames.step; }
            set { RenumberFrames.step = value; }
        }
        public RenumberFrames()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            step = textBox1.Text;
            this.Close();
        }
    }
}
