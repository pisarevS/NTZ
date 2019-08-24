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
    public partial class FindAndReplace : Form
    {
        private static string find = "";

        public static string Find
        {
            get { return FindAndReplace.find; }
            set { FindAndReplace.find = value; }
        }
        private static string replace = "";

        public static string Replace
        {
            get { return FindAndReplace.replace; }
            set { FindAndReplace.replace = value; }
        }

        public FindAndReplace()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            find = textBox1.Text;
            replace = textBox2.Text;
            this.Close();
        }
    }
}
