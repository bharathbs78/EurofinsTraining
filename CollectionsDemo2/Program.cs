using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo2//Dynamic collections
{
    internal class Program//creating 
    {
        static void Main(string[] args)
        {
            DynamicIntArray numbers = new DynamicIntArray();
            for(int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }
            for(int i = 0; i < numbers.Size; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }
        }
    }
    class DynamicIntArray
    {
        public int Size 
        {
            get 
            { 
                return index;
            } 
        }
        private int[] numbers=new int[10];
        private int index = 0;
        public DynamicIntArray() { }
        public void Add(int value)
        {
            if (index < numbers.Length)
                numbers[index++] = value;
            else
            {
                int[] temp = new int[numbers.Length * 2];
                for(int i = 0; i < numbers.Length; i++)
                {
                    temp[i] = numbers[i];
                }
                numbers = temp;//point to new array
                numbers[index++] = value;
            }

        }

        internal int Get(int i)
        {
            return numbers[i];
        }
    }
}
