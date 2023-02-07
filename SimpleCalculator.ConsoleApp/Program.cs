using SimpleCalculator.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.ConsoleApp
{
    //internal is visible to the assembly "not solution"
    internal class Program//class level SRP
    {
        static void Main(string[] args)//UI Logic
        {
            //Accept 2 ints and find sum
            int fno, sno;
            int sum = 0;
            Console.Write("Enter 1st number");
            fno = int.Parse(Console.ReadLine());//alternate to Convert.toInt32
            Console.Write("Enter 2nd number");
            sno = int.Parse(Console.ReadLine());//user interaction end business logic start
            //sum=fno+sno;//business logic
            sum = Calculator.FindSum(fno, sno);
            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");//for placeholders use $ in the beginning else it treats as a normal string
        }
    }
 /*   class Calculator //only BL
    { 
        //method private by default
        public static int FindSum(int fno,int sno)//SRP - Single Responsibility Principle ,BL , initially method level
        {
            return fno+sno;
        }
    }*/
}
