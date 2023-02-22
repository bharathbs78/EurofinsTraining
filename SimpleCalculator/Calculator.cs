using SimpleCalculator.DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class Calculator
    {
        //find sum of 2 ints
        //positive numbers only
        //even numbers only
        //throws suitable exception if business rules violated
        //save to file
        private ICalculatorRepo repo = null;
        public Calculator(ICalculatorRepo repo)
        {
            this.repo= repo;
        }
        public int Sum(int x, int y)
        {
            if (x >= 0 && y >= 0)
                if (x % 2 == 0 && y % 2 == 0)
                {
                    int sum = x + y;
                    //ICalculatorRepo cal=new CalculatorRepo(); // USE DIP here
                    //cal.Save(sum.ToString());
                    //mocking - manula and automatic
                    repo.Save(sum.ToString());
                    return sum;
                }
                else
                    throw new OddNumberException("Number(s) cannot be odd");
            else
                throw new NumberNegativeException("Numbers cannot be negative");
        }
        //public int Subtract(int x, int y)
        //{
        //    return x - y;
        //}
    }
}
