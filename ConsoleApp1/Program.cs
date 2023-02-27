using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MtDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task tt2 = new Task(()=>M2(100));
            Task<int> tt3 = new Task<int>(M3);
            tt3.Start();
            int r = tt3.Result;// blocks the current thread until result is obtained
            Task<int> tt4 = new Task<int>(() => M4(100));
            tt4.Start();
            Console.WriteLine(tt4.Result);
            Thread t1 = new Thread(M1);
            Thread t2 = new Thread(()=> { M2(100); });//parameterized threadstart delegate has only 1 parameter of object.
            //Thread t3 = new Thread(M3);
            //Thread t4 = new Thread(M4);
            Task tt1 = Task.Factory.StartNew(M1);//starts immediately
        }
        static void M1() { }
        static void M2(int i) { }
        static int M3() { return 1; }
        static int M4(int i) { return i; }
    }
}
