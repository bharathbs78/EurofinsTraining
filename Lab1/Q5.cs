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
            int sum = 0;
            int[] scores = new int[3];
            for(int i = 0; i < 3; i++)
            {
                scores[i]=Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }

        }
    }
}
