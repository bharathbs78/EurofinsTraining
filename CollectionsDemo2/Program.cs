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
            DynamicArray<Double> numbers2 = new DynamicArray<Double>();
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
    class DynamicArray<T>//T-type
    {
        public int Size
        {
            get
            {
                return index;
            }
        }
        private T[] numbers = new T[10];
        private int index = 0;
        public DynamicArray()
        {

        }

        public void Add(T value)
        {
            if (index < numbers.Length)
                numbers[index++] = value;
            else
            {
                Array.Resize(ref numbers, numbers.Length * 2);
                numbers[index++] = value;
            }

        }

        internal T Get(int i)
        {
            return numbers[i];
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
                //int[] temp = new int[numbers.Length * 2];
                //for(int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}
               // Array.Copy(numbers,temp, numbers.Length);// Always use built-in libraries
                //numbers = temp;//point to new array
                Array.Resize(ref numbers, numbers.Length*2);
                numbers[index++] = value;
            }

        }

        internal int Get(int i)
        {
            return numbers[i];
        }
    }
}
