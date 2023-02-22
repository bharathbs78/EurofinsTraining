using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExercises
{
    internal class Part1
    {
        static void Main(string[] args)
        {
            int[] arr=new int[10];
            try
            {
                Console.WriteLine(arr[9]);
                int num1=int.Parse(Console.ReadLine());
                int num2=int.Parse(Console.ReadLine());
                num1 = num1 / num2;
                Write("Data");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace.ToString());
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Write(string str)
        {
            StreamWriter sw=new StreamWriter("file.txt");
            try {
                sw.WriteLine(str);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
