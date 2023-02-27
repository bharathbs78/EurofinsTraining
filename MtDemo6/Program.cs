using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MtDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M1();
        }
        static void M1()
        {
            int pcount=Environment.ProcessorCount;
            Console.WriteLine(pcount);
            ParallelOptions opts= new ParallelOptions();
            opts.MaxDegreeOfParallelism= pcount/2;
            HashSet<int> set = new HashSet<int>();
            Object obj= new Object();
            Parallel.For(0, 10000000,opts, i =>
            {
                lock (obj)
                {
                    set.Add(Thread.CurrentThread.ManagedThreadId);
                }
                //Something
                //do this to make sure that the current application doesn't take up all system resources
            });
            Console.WriteLine(set.Count);
        }
    }
}
