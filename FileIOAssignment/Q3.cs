using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileIOAssignment
{
    internal class Q3
    {
        static void Main(string[] args)
        {
            Stream s = File.Create("file.txt");
            StreamWriter sw= new StreamWriter(s);
            sw.WriteLine("Something");
            sw.Close();
            s.Close();
            StreamReader sr = new StreamReader("file.txt");
            Console.WriteLine(sr.ReadLine());
            sr.Close();
            File.Copy("file.txt", "file1.txt");
            File.Move("file.txt", "file2.txt");
            File.Replace("file2.txt", "file1.txt","file.txt");
        }
    }
}
