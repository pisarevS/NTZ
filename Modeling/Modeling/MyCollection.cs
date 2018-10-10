using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    class MyCollection : IMyCollectoin
    {
        private string[] gCode = { "DEF REAL", "DEF INT" };
        public static List<string> ListCadrs { get; set; } = new List<string>();
        public Dictionary<string, string> ListVariables { get; set; } = new Dictionary<string, string>();
        

        public void Add(string cadr)
        {

            if (cadr.Contains(".")||cadr.Contains(";"))
            {                
                cadr= cadr.Replace(".", ",");
                if (cadr.IndexOf(';') != -1)
                cadr = cadr.Remove(cadr.IndexOf(';'));
                ListCadrs.Add(cadr);                
            }
            else { ListCadrs.Add(cadr); }                                                            
        }

        public void ReplaceVariables()
        {
            string key = "";
            string value = "";
            string cadr = "";


            for (int i = 0; i < ListCadrs.Count; i++)
            {
                cadr = ListCadrs[i];
                for (int h = 0; h < gCode.Length; h++)
                {
                    if (cadr.Contains(gCode[h]))
                    {
                        int n = cadr.IndexOf(gCode[h], 0) + gCode[h].Length;
                        for (int j = n; j < cadr.IndexOf('=', 0); j++)
                        {
                            key += cadr[j];
                            key = key.Replace(" ", "");
                        }
                        for (int g = cadr.IndexOf('=', 0) + 1; g < cadr.Length; g++)
                        {
                            value += cadr[g];
                            value = value.Replace(" ", "");
                        }
                        try
                        {
                            ListVariables.Add(key, value);
                            key = null;
                            value = null;
                        }
                        catch { }
                    }

                }
            }
            foreach (KeyValuePair<string, string> keyValue in ListVariables)
            {
                key = keyValue.Key;
                value = keyValue.Value;
                for (int i = 0; i < ListCadrs.Count; i++)
                {
                    for(int h = 0; h < gCode.Length; h++)
                    {
                        if (!ListCadrs[i].Contains(gCode[h]))
                        {
                            if (ListCadrs[i].Contains(key))
                            {
                                string str = ListCadrs[i].Replace(key, value);
                                ListCadrs[i] = null;
                                ListCadrs[i] = str;
                                str = null;
                            }
                        }
                    }                  
                }
            }
        }
    }
}
