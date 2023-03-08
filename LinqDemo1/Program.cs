using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evenNumbers=GetEvens(numbers);
            numbers.Add(10);
            foreach (var evenNumber in evenNumbers)
                Console.WriteLine(evenNumber+" ");
            var evens = numbers.Where(n => n % 2 == 0).Select(n=>n).OrderByDescending(n=>n).ToList();
            foreach (var evenNumber in evens)
                Console.WriteLine(evenNumber + " ");
        }
        public static List<int> GetEvens(List<int> ints)
        {
            var evenNumbers = from n in ints where n % 2 == 0 select n;

            return evenNumbers.ToList();
        }
    }
}
