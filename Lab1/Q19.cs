using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q19
    {
        public static int ReadInt() => int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
        }
        static void Solve() 
        { 
            int nTerms = 0, i = 0, a = 1, sign = 1;
            nTerms = ReadInt(); 
            for (i = 1; i < nTerms; i++)
            {
                Console.WriteLine(a * sign);
                a += i * i; sign = -sign; 
            } 
            i = 0;
            a = 1;
            int b = 0, next = 1;
            nTerms = ReadInt();
            for (i = 1; i < nTerms; i++)
            { 
                Console.WriteLine(next);
                a = b;
                b = next;
                next = a + b;
            } 
            a = 1;
            b = -2;
            nTerms = ReadInt(); 
            for (i = 1; i < nTerms; i++) 
            {
                Console.WriteLine(+a + " " + b); 
                a += 3;
                b -= 4; 
            }
            a = 1;
            b = 5;
            int c = 8;
            next = 14;
            nTerms = ReadInt();
            for (i = 0; i < nTerms; i++) 
            { 
                Console.WriteLine(next);
                a = b; 
                b = c;
                c = next;
                next = a + b + c;
            }
        }

    }
}
