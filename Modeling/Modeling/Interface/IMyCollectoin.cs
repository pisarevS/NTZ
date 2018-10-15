using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modeling
{
    interface IMyCollectoin
    {
        void Add(string cadr, List<string> List);
        void ReadProgramVariables();
        void ReplaceVariables(List<string> List);
    }
}
