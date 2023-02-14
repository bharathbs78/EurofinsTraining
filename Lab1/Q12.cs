using System;
using System.Collections.Generic;
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
                    break;
                case 1:
                    for(int j = 1; j <= n; j++)
                    {
                        if(j%2!=0)
                            Console.WriteLine(j+" ");
                        else
                            Console.WriteLine("-"+j +" ");
                    }
                    break;
            }
        }
    }
}
