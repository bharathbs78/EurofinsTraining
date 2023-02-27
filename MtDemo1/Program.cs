using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MtDemo1
{
    internal class Program
    {
        static void Main(string[] args)//Main Thread
        {
            Console.WriteLine($"Processor Count : "+Environment.ProcessorCount);
            M3();
            return;
           Stopwatch sw = Stopwatch.StartNew();
            //Console.WriteLine($"Main : {Thread.CurrentThread.ManagedThreadId}");
            //M1();
            //// Console.WriteLine($"Main : {Thread.CurrentThread.ManagedThreadId}");
            //M2();
            //// Console.WriteLine($"Main : {Thread.CurrentThread.ManagedThreadId}");
            //Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Using Classic Thread");
            sw = Stopwatch.StartNew();
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();
            Thread t2 = new Thread(M2);
            t2.Start();
            // wait for child threads to join back to the main thread.
            t1.Join();
            t2.Join();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Using TPL -Task");
            sw = Stopwatch.StartNew();
            Task task1 = new Task(M1);
            task1.Start();
            Task task2 = new Task(M2);
            task2.Start();
            task1.Wait();
            task2.Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Using TPl-Parallel");
            sw = Stopwatch.StartNew();
            Parallel.Invoke(M1, M2);
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Using TPL-Parallel For");
            sw = Stopwatch.StartNew();
            Parallel.Invoke(M11, M22);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        static void M1()
        {
            Console.WriteLine($"M1 : {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }
        }
        static void M2()
        {
            Console.WriteLine($"M2 : {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }
        }
        static void M11()
        {
            Console.WriteLine($"M11 : {Thread.CurrentThread.ManagedThreadId}");
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(100);
            });
        }
        static void M22()
        {
            Console.WriteLine($"M22 : {Thread.CurrentThread.ManagedThreadId}");
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(100);
            });
        }
        static void M3()
        {
            Parallel.For(0, 101, i => { Console.WriteLine(Thread.CurrentThread.ManagedThreadId); Thread.Sleep(100); }) ;
        }
    }
}
