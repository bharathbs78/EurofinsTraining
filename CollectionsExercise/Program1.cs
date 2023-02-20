using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExercise
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,int> map = new SortedDictionary<string,int>();
            char[] ch = { ' ' };
            string[] str=Console.ReadLine().Split(ch);
            foreach(var strings in str)
            {
                if (map.ContainsKey(strings))
                {
                    int val = map[strings];
                    map.Remove(strings);
                    map.Add(strings, ++val);
                }
                else
                    map.Add(strings, 1);
            }
            Console.Write("[");
            foreach(var value in map.Keys)
            {
                Console.Write($"{value} = {map[value]},");
            }
            Console.WriteLine("]");
        }
    }
}
