using System.Diagnostics;

namespace Учёт_колёс
{
    internal class _Close
    {
        public void CloseProcess()
        {
            Process[] List;
            List = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in List)
            {
                proc.Kill();
            }
        }
    }
}