using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    class MyCollection : IMyCollectoin
    {
        private string[] gCode = { "DEF REAL", "DEF INT" };

        private static List<string> listCadrs = new List<string>();

        private static List<string> listParameter = new List<string>();

        private  Dictionary<string, string> listVariables = new Dictionary<string, string>();

        private static List<string> listTemp = new List<string>();

        private static List<string> errorList = new List<string>();

        public static List<string> ErrorList
        {
            get { return errorList; }
            set { errorList = value; }
        }

        public static List<string> ListTemp
        {
            get { return MyCollection.listTemp; }
            set { MyCollection.listTemp = value; }
        }

        public static List<string> ListCadrs
        {
            get { return MyCollection.listCadrs; }
            set { MyCollection.listCadrs = value; }
        }
        
        public static List<string> ListParameter
        {
            get { return MyCollection.listParameter; }
            set { MyCollection.listParameter = value; }
        }
        
        public  Dictionary<string, string> ListVariables
        {
            get { return listVariables; }
            set { listVariables = value; }
        }

        public void Add(string cadr, List<string> List)
        {            
            if (cadr.Contains(".") || cadr.Contains(";"))
            {
                cadr = cadr.Replace(".", ",");
                if (cadr.IndexOf(';') != -1)
                {
                    cadr = cadr.Remove(cadr.IndexOf(';'));
                }
                if (cadr.Contains("MSG("))
                {
                    cadr = cadr.Replace(cadr, "");
                }
                List.Add(cadr);
            }
            else { List.Add(cadr); }
        }

        public void ReadParametrVariables()
        {
            string key = "";
            string value = "";
            string parametr = "";
            listVariables.Add("N_GANTRYPOS_X", "650");
            listVariables.Add("N_GANTRYPOS_Z", "250");
            listVariables.Add("N_GANTRYPOS_U", "650");
            listVariables.Add("N_GANTRYPOS_W", "250");
            listVariables.Add("$P_TOOLR", "16");

            for (int i = 0; i < listParameter.Count; i++)
            {
                parametr = listParameter[i];
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
                        listVariables.Add(key, value);
                        key = null;
                        value = null;
                    }
                    catch { }
                }
                ReplaceVariables(listParameter);
            }
        }

        public void ReadProgramVariables()
        {
            string key = "";
            string value = "";
            string cadr = "";
            for (int i = 0; i < listCadrs.Count; i++)
            {
                cadr = listCadrs[i];
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
                            listVariables.Add(key, value);
                            key = null;
                            value = null;
                        }
                        catch { }
                    }
                }
            }
            ReplaceVariables(listCadrs);
        }

        public void ReplaceVariables(List<string> List)
        {
            string key = "";
            string value = "";

            foreach (KeyValuePair<string, string> keyValue in listVariables)
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
