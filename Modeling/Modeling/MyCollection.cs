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
        public static List<string> ListParameter { get; set; } = new List<string>();
        public Dictionary<string, string> ListVariables { get; set; } = new Dictionary<string, string>();

        public void Add(string cadr, List<string> List)
        {
            if (cadr.Contains(".") || cadr.Contains(";"))
            {
                cadr = cadr.Replace(".", ",");
                if (cadr.IndexOf(';') != -1)
                    cadr = cadr.Remove(cadr.IndexOf(';'));
                List.Add(cadr);
            }
            else { List.Add(cadr); }
        }

        public void ReadParametrVariables()
        {
            string key = "";
            string value = "";
            string parametr = "";
            ListVariables.Add("N_GANTRYPOS_X", "650");
            ListVariables.Add("N_GANTRYPOS_Z", "250");
            ListVariables.Add("N_GANTRYPOS_U", "650");
            ListVariables.Add("N_GANTRYPOS_W", "250");
            ListVariables.Add("$P_TOOLR", "16");

            for (int i = 0; i < ListParameter.Count; i++)
            {
                parametr = ListParameter[i];
                if (parametr.Contains("="))
                {
                    for (int j = 0; j < parametr.IndexOf('=', 0); j++)
                    {
                        key += parametr[j];
                        key = key.Replace(" ", "");
                    }
                    for (int g = parametr.IndexOf('=', 0) + 1; g < parametr.Length; g++)
                    {
                        value += parametr[g];
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
                ReplaceVariables(ListParameter);
            }
        }

        public void ReadProgramVariables()
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
            ReplaceVariables(ListCadrs);
        }

        public void ReplaceVariables(List<string> List)
        {
            string key = "";
            string value = "";

            foreach (KeyValuePair<string, string> keyValue in ListVariables)
            {
                key = keyValue.Key;
                value = keyValue.Value;
                for (int i = 0; i < List.Count; i++)
                {
                    for (int h = 0; h < gCode.Length; h++)
                    {
                        if (!List[i].Contains(gCode[h]))
                        {
                            if (List[i].Contains(key))
                            {
                                string str = List[i].Replace(key, value);
                                List[i] = null;
                                List[i] = str;
                                str = null;
                            }
                        }
                    }
                }
            }
        }
    }
}
