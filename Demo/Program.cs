using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Base class ref variable can hold derived type objects
            IShape s=new Rectangle();//dynamic polymorphism
            s.CalculateArea(10, 10);
        }
    }
    interface IShape// naming convention 
    {
        //public void draw()
        //{
        //    Console.WriteLine("drawing shape");
        //}
        void Draw();
        double CalculateArea(double width, double height);
    }
    class Rectangle:IShape 
    {
        public  double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating Rectangle Area");
            return width * height;
        }

        public  void Draw()
        {
            Console.WriteLine("Rectangle");
        }
    }
    class Triangle : IShape
    {
        public  void Draw()
        {
            Console.WriteLine("Triangle");
        }
        public double CalculateArea(double width,double height)
        {
            Console.WriteLine("Calculating triangle Area..");
            return (width*height)/2;
        }
    }
}
