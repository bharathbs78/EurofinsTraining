using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q12
    {
        static void Main(string[] args)
        {
            int choice;
            int n;
            Console.WriteLine("Enter n");
            n=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter choice");
            choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 0:
                    int i = 2;
                    while (i * i < n) {
                        Console.WriteLine(i * i + " ");
                        i++;
                    }
                    i = 0;
                    break;
                case 1:
                    for(int a = 1; a <= n; a++)
                    {
                        if(a%2!=0)
                            Console.WriteLine(a+" ");
                        else
                            Console.WriteLine("-"+a +" ");
                    }
                    break;
                case 2:
                    for( int b=1;Math.Pow(b,3)<=n;b++)
                        Console.WriteLine(Math.Pow(b,3));
                    break;
                case 3:
                    int  j = 4, k = 7,next;
                    i = 1;
                    if(n>=7)
                        Console.WriteLine($"{i} {j} {k}");
                    else if(n>=4)
                        Console.WriteLine($"{i} {j}");
                    else if(n>=1)
                        Console.WriteLine($"{i}");
                    next = i + j + k;
                    while (next <= n)
                    {
                        Console.WriteLine($" {next}");
                        i = j;
                        j = k;
                        k=next;

                        next = i + j + k;
                    }
                    break;
                case 4:
                    break;
            }
        }
    }
}
