using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace MtDemo5
{
    public class Program
    {
        static void Main(string[] args)
        {
            BigData data= new BigData();
            //data.Fill();
            //data.Fill();
            Parallel.Invoke(data.Fill, data.Fill);
            Console.WriteLine(data.Count);
        }
    }
    public class BigData
    {
        private ConcurrentStack<int> stack = new ConcurrentStack<int>();
        //[MethodImpl(MethodImplOptions.Synchronized)]//ignores multithreaded calls
        public void Fill()
        {
            for(int i = 0; i < 10000000; i++)
            {
                // Monitor.Enter(stack);
                stack.Push(i);
                //  Monitor.Exit(stack);
            }
        }
        public long Count
        {
            get { return stack.Count; }
        }
    }
}
