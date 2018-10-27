using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Modeling
{
    class ReadFile
    {
        private StreamReader sr;

        public static List<string> Ignor { get; set; } = new List<string>();

        public ReadFile()
        {
            string path = "ignor.txt";
            sr = new StreamReader(path, Encoding.Default);
            while (true)
            {
                string temp = sr.ReadLine();
                if (temp == null) break;
                Ignor.Add(temp);
            }
            sr.Close();
        }
    }
}
