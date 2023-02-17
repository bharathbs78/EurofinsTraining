using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q19
    {
        static void Main(string[] args)
        {
            int number, power;
            int result=1;
            number=int.Parse(Console.ReadLine());
            power = int.Parse(Console.ReadLine());
            for(int i = 1; i <= power; i++)
            {
                result = result*number;
            }
            Console.WriteLine(result);
        }
    }
}
