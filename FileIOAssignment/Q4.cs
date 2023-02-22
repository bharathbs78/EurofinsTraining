using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOAssignment
{
    internal class Q4
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\WorkingWithDirectoryInfo");
            //if (!di.Exists)
            //{
            //    di.Create();
            //}
            //else
            //{
            //    di.CreateSubdirectory("sub2");
            //}
            foreach (var d in di.GetDirectories()) { Console.WriteLine(d.Name); }
            di.MoveTo(@"C:\folder");
            Console.WriteLine(di.Parent);// null as parent is C:

        }
    }
}
