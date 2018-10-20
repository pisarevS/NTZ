using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    class Check
    {
        public static bool CheckSymbol(char input)
        {
            switch (input)
            {
                case '+':
                    return true;
                case '-':
                    return true;
                case '=':
                    return true;
                case '0':
                    return true;
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
            }
            return false;
        }

        public static bool ReadUp(char input)
        {
            switch (input)
            {
                case ' ':
                    return false;
                case 'Z':
                    return false;
                case 'W':
                    return false;
                case 'F':
                    return false;
                case 'M':
                    return false;
                case 'G':
                    return false;
                case 'X':
                    return false;
                case 'U':
                    return false;
            }
            return true;
        }

        public static bool isDigit(char input)
        {
            switch (input)
            {
                case '0':
                    return true;
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
            }
            return false;
        }

        public static bool isG17()
        {
            for (int a = 0; a < MyCollection.ListCadrs.Count; a++)
            {
                if (MyCollection.ListCadrs[a].Contains("G17"))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
