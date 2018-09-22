using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modeling
{
    class MyCollection : IMyCollectoin
    {
        private List<string> listCadrs = new List<string>();
    
        private Dictionary<string, int> variables = new Dictionary<string, int>();
        private string gCode;
        private string cadr = "";

        public MyCollection()
        {
            gCode = "REAL";
        }

        public List<string> List { get => listCadrs; set => listCadrs = value; }
        public Dictionary<string, int> Variables { get => variables; set => variables = value; }

        public void Add(string cadr)
        {
            listCadrs.Add(cadr);
        }

        public void ReadVariables()
        {
            string str = "";
            string number = "";
            for (int i = 0; i < listCadrs.Count; i++)
            {
                cadr = listCadrs[i];
                if (cadr.Contains(gCode))
                {
                    int n = cadr.IndexOf(gCode, 0) + gCode.Length;
                    for (int j = n; j < cadr.IndexOf('=', 0); j++)
                    {
                        str += cadr[j];
                        str = str.Replace(" ", "");
                    }
                    for(int g= cadr.IndexOf('=', 0)+1; g < cadr.Length; g++)
                    {
                        number += cadr[g];
                        number = number.Replace(" ", "");                       
                    }
                    variables.Add(str, Convert.ToInt32(number));
                    str = null;
                    number = null;
                }
            }
        }
    }
}
