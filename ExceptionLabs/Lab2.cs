using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLabs
{
    internal class Lab2
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader sr = File.OpenText("C:\\abc.txt");
                int input1, input2, output;
                input1=int.Parse(sr.ReadLine());
                input2=int.Parse(sr.ReadLine());
                output=input1/input2;
                sr.Close();
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
