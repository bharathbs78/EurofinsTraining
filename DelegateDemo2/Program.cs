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
            //ProcessManager.GetProcessList(NoFilter);
            ////client 2 -
            //ProcessManager.ShowProcessList("s"); // starting with s
            //FilterDelegate filterDelegate =new FiltrDelegate(FilterBySize);
            //ProcessManager.GetProcessList(filterDelegate);
            ProcessManager.GetProcessList(FilterByName);
            //client 3 - Once in lifetime call of a particular filter. Use Anonymous Delegates here.
            // ProcessManager.GetProcessList(delegate(Process process) { return process.WorkingSet64 >= 50 * 1024 * 1024; });
            //Lambdas 
            //Lambda Statements
            // ProcessManager.GetProcessList((Process process) => { return process.WorkingSet64 >= 50 * 1025 * 1024; });
            //Lambda Expressions
            // ProcessManager.GetProcessList((Process process) =>  process.WorkingSet64 >= 50 * 1025 * 1024 );
            ProcessManager.GetProcessList( process => process.WorkingSet64 >= 50 * 1025 * 1024);//Datatype not required and for single parameter brackets are not required


        }
        //client 1
        public static bool NoFilter(Process process)
        {
            return true;
        }
        public static bool FilterByName(Process process)
        {
            return process.ProcessName.StartsWith("S");
        }
        //public static bool FilterBySize(Process process)
        //{
        //    return process.WorkingSet64>=50*1024*1024;
        //}

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
