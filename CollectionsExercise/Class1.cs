using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExercise
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            string str, str1;
            str=Console.ReadLine();
            str1=Console.ReadLine();
            compare(str, str1);
        }
        static void compare(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                Console.WriteLine("String 1 is greater");
            }
            else if(str1.Length < str2.Length)
            {
                Console.WriteLine("String 2 is greter");
            }
            else
                Console.WriteLine("Both are equal");
        }
    }
}
