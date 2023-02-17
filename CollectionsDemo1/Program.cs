using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 10;
            //int[] numbers = new int[10];//[] is called subscript operator
            //numbers[0] = a;
            //a = numbers[0];
            ////default 0 for numeric data types and null for other data types
            //int[] numbers2 = new int[5/*can be a variable also but not when you use initialization list*/]
            //{
            //    1,2,3,4,5
            //};//initialization List
            //int[] numbers3 =/* new int[]* optional*/ { 1, 2, 3, 4, 5, 6 };//automatically takes the size by counting from the initialization list

            //Item[] items = new Item[5];
            //Item item = new Item { ItemId = 1, Name = "IPhone X", Cost = 75000 };
            //numbers3.Sum();
            //numbers3.Min();
            //numbers3.Max();
            //numbers3.Average();
            //Array.Sort(numbers3);//Array class has Array Algorithms
            //Array.Reverse(numbers3);
            //Array.BinarySearch(numbers3,3);*/
            Item[] items = new Item[3];
            var i1 = new Item { ItemId = 1, Name = "bsha", Cost = 2121201 };
            var i2 = new Item { ItemId = 2, Name = "bac", Cost = 33212 };
            var i3 = new Item { ItemId = 3, Name = "abc", Cost = 1871323 };
            items[0] = i1;
            items[1]= i2;
            items[2]= i3;
            //give Icomparer should be given - contract between sort() and array/ IComparable
            Array.Sort(items,new ItemCostComparer());//2nd parameter is the object of comparer type, if not mentioned uses Item class implementation or gives error if no implementation in Item class
            foreach(var item in items) 
            {
                Console.WriteLine(item.Cost);
            }
            Array.Sort(items,new ItemNameComparer());
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }


        }
    }
    class Item:IComparable<Item>// non generic version
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public int CompareTo(Item item)// for generic we mention the data type
        {
            if(this.Cost>item.Cost) return -1;
            else if(this.Cost<item.Cost) return 1; else return 0;
        }

        //public int CompareTo(object obj/*next object value*/)
        //{
        //    Item item= obj as Item;
        //    if (this.Cost > item.Cost) return 1;
        //    else if (this.Cost < item.Cost) return -1;
        //    else return 0;
        //}

    }
    //IComparer - 2 parameters, if source code is not available 
    //IComparable - single parameter , if you are author of Item class then modify the source code an implement this
    class ItemCostComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.Cost > y.Cost)
                return 1;
            else if(x.Cost< y.Cost) return -1;
            else return 0;
        }
    }
    class ItemNameComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

}
