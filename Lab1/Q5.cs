using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q5
    {
        static void Main(string[] args)
        {
            string name;
            int[] scores = new int[3];
            double average;
            name= Console.ReadLine();
            for(int i = 0; i < scores.Length; i++)
            {
                scores[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine(scores.Sum());
            average = scores.Average();
            Console.WriteLine(average);
            if(average<35)
                Console.WriteLine("Fail");
            else if(average<50)
                Console.WriteLine("Pass");
            else if(average<60)
                Console.WriteLine("2nd");
            else
                Console.WriteLine("1st");
            
        }
    }
}
