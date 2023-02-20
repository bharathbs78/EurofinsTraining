using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q27
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());
            Array.Sort(arr,new Comparer());
            BinarySearch(arr, n,0,arr.Length-1);
        }
        static void BinarySearch(int[]arr,int n,int l,int h) 
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
            int mid = (h + l) / 2;
            if (l >= h)
            {
                Console.WriteLine("Not found");
                return;
            }
            else if (arr[mid] == n)
            {
                Console.WriteLine("Found at index " + mid);
                return; 
            }
            else if (n > arr[mid])
                BinarySearch(arr, n, mid + 1, h);
            else if (n < arr[mid])
                BinarySearch(arr, n, l, mid-1);
        }
    }

    class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}
