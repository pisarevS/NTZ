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

        private static List<string> ignor = new List<string>();

        public static List<string> Ignor
        {
            get { return ReadFile.ignor; }
            set { ReadFile.ignor = value; }
        }

        public ReadFile()
        {
            string path = "ignor.txt";
            sr = new StreamReader(path, Encoding.Default);
            while (true)
            {
                string temp = sr.ReadLine();
                if (temp == null) break;
                ignor.Add(temp);
            }
            sr.Close();
        }
    }
}
