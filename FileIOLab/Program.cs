using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\Admin\\Desktop\\names.txt");
            List<string> nameValues= new List<string>();
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Replace("\"","");
                string[] names = line.Split(',');
                foreach(var name in names)
                {
                    nameValues.Add(name);
                }
                nameValues.Sort((n1,n2)=> n1.CompareTo(n2));
                long sum = 0;
                for (int i= 0;i <nameValues.Count;i++)
                {
                    Console.WriteLine($"{nameValues[i]} : {GetNameCode(nameValues[i])}");
                    sum += GetNameCode(nameValues[i])*(i+1);

                }
                Console.WriteLine(sum);
            }
        }
        static long GetNameCode(string name)
        {
            return name.Sum(c => (c - 'A') +1);
            
        }
    }
}//57656785
