using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("path");
            while (sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            StreamWriter sw = new StreamWriter("path", true);
            while (true)
            {
                Console.WriteLine("Question1");
                string response=Console.ReadLine();
                if (response == "")
                    break;
                sw.WriteLine(response);   
            }
            sw.Close();
        }
    }
}
