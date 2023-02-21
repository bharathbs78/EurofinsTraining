using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DelegateDemo2
{
    public delegate bool FilterDelegate(Process process);

    internal class Program
    {
        static void Main(string[] args)
        {
            ////client 1 - 
            //ProcessManager.ShowProcessList();
            ////client 2 -
            //ProcessManager.ShowProcessList("s"); // starting with s
            ProcessManager.GetProcessList(FilterByName);
        }
        public static bool FilterByName(Process process)
        {
            return process.ProcessName.StartsWith("S");
        }
        public static bool FilterBySize(Process process)
        {
            return process.WorkingSet64>=50*1024*1024;
        }
    }
    class ProcessManager
    {
        
        public static void GetProcessList(FilterDelegate processDelegate)
        {
            foreach(var process in Process.GetProcesses())
                if(processDelegate(process))
                    Console.WriteLine(process.ProcessName);
        }
    }
}
