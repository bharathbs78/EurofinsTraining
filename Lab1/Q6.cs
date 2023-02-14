using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q6
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter 3 numbers");
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            stack.Push(arr[0]);
            for(int i=1;i<arr.Length;i++)
            {
                if (Convert.ToInt32(stack.Peek()) > arr[i])
                {
                    int var=Convert.ToInt32(stack.Pop());
                    stack.Push(arr[i]);
                    stack.Push(var);
                }
                else
                    stack.Push(arr[i]);    
            }
            Console.WriteLine($"Greatest number is {stack.Pop()}");
            Console.WriteLine($"Second Greatest number is {stack.Pop()}");

        }
    }
}
