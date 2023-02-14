using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q13
    {
        static void Main(string[] args)
        {
            int n, m;
            int sum=0;
            bool isPrime;
            Console.WriteLine("Enter n and m");
            n=int.Parse(Console.ReadLine());
            m= int.Parse(Console.ReadLine());
            if (n == 1)
                n++;
            while (n < m)
            {
                isPrime = true;
                for(int i = 2; i <=Math.Sqrt(n); i++)
                {
                    if(n%i==0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    sum += n;
                    Console.WriteLine(n);
                }
                n++;
            }
            Console.WriteLine(sum);
        }
    }
}
