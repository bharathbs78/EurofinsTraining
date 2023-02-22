using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOAssignment
{
    internal class Q2
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("file.txt");
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Length);
            Stream stream = File.Open("file.txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.WriteLine("Something");
            streamWriter.Close();
            stream.Close();
            file.CopyTo("file1.txt");
            file.MoveTo("file2.txt");
            stream = File.OpenRead("file1.txt");
            StreamReader sr=new StreamReader(stream);
            Console.WriteLine(sr.ReadLine());
            stream.Close();
            sr.Close();

            sr=File.OpenText("file2.txt");
            Console.WriteLine(sr.ReadLine());
            sr.Close();

        }
    }
}
