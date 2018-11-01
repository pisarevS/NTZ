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
        private static string find="";
        private static string replace = "";

        public FindAndReplace()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static string Find { get => find; set => find = value; }
        public static string Replace { get => replace; set => replace = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            find = textBox1.Text;
            replace = textBox2.Text;
            this.Close();
        }
    }
}
