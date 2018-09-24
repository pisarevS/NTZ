using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    class MyCollection : IMyCollectoin
    {
        private string gCode = "REAL";
        public List<string> ListCadrs { get; set; } = new List<string>();
        public Dictionary<string, string> ListVariables { get; set; } = new Dictionary<string, string>();

        public void Add(string cadr) => ListCadrs.Add(cadr);

        public void ReplaceVariables()
        {
            string key = "";
            string value = "";
            string cadr = "";
            for (int i = 0; i < ListCadrs.Count; i++)
            {
                cadr = ListCadrs[i];
                if (cadr.Contains(gCode))
                {
                    int n = cadr.IndexOf(gCode, 0) + gCode.Length;
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
                    ListVariables.Add(key, value);
                    key = null;
                    value = null;
                }
            }
            foreach (KeyValuePair<string, string> keyValue in ListVariables)
            {
                key = keyValue.Key;
                value = keyValue.Value;
                for (int i = 0; i < ListCadrs.Count; i++)
                {
                    if (!ListCadrs[i].Contains(gCode))
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
