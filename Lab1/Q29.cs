using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q29
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter m");
            int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
            if (n == m)
            {
                int i,notIdentity=0;
                for ( i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i == j && arr[i, j] != 1 || i != j && arr[i, j] != 0)
                        {
                            Console.WriteLine("Not Identity");
                            notIdentity++;
                            break;
                        }
                    }
                    if (notIdentity != 0)
                        break;
                }
                if(i==n)
                        Console.WriteLine("Identity");
            }
            else
            {
                Console.WriteLine("Not Identity");
            }

        }
    }
}
