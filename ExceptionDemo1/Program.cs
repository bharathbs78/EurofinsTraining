using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ExceptionDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fno, sno, sum;
            while (true)
            {
                try
                {
                    //open db
                    Console.Write("Enter First Number");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter second number");
                    sno = int.Parse(Console.ReadLine());
                    sum = Calculator.sum(fno, sno);
                    //save into db
                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                    //close db connection -- doesn't execute if an exception is thrown
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Enter only numbers");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Enter numbers in the range " + int.MinValue + " " + int.MaxValue);
                }
                catch (NegativeNumberException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NumberZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NonEvenException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //Console.WriteLine(e.InnerException.Message);// to sidplay innerexception message
                }//Catch All block - handles all exceptions
                finally 
                {
                    //close the connection here. since this always executed. 
                }
            }
        }//UI Logic
        
    }
    /// <summary>
    /// Calculator will be used for finding mathematical calculations
    /// </summary>
    class Calculator//BL
    {
        /// <summary>
        /// sum of non-negative, non-zero,even numbers
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        /// <returns>sum of a and b</returns>
        /// <exception cref="NonEvenException"></exception>
        /// <exception cref="NegativeNumberException"></exception>
        /// <exception cref="NumberZeroException"></exception>
        public static int sum(int a,int b)
        {
            try
            {
                InputValidator.validate(a, b);
            }
            catch(Exception e)
            {
                //log 
                LogManager.LoadConfiguration("nlog.config");
                var log = LogManager.GetCurrentClassLogger();
                log.Debug("Starting up");
                log.Error(e.Message);
                throw e;
            }
            int sum = a + b;
            try
            {
                CalculatorRepository.Save($"{a}+{b}={sum}");
            }
            catch(Exception e )
            {
                UnableToSaveException exp = new UnableToSaveException("Unable to save the calculated output",e);//never discard original exception
                throw exp;
            }
            return sum;
        }
    }
    class NonEvenException : ApplicationException
    {
        public NonEvenException(string message) : base(message) { }
    }  
    class NegativeNumberException : ApplicationException 
    {
        public NegativeNumberException(string message) : base(message)
        {

        }
    }
    class NumberZeroException:ApplicationException
    {
        public NumberZeroException(string message) : base(message) { }
    }
    class InputValidator
    {
        public static void validate(int a,int b) {
            if (a < 0 || b < 0)
                throw new NegativeNumberException("Enter only positive numbers");
            else if (a == 0 || b == 0)
                throw new NumberZeroException("Enter non zero numbers only");
            else if (a % 2 != 0 || b % 2 != 0)
                throw new NonEvenException("Enter even numbers only");
    }
    }
    class UnableToSaveException : ApplicationException
    {
       // public UnableToSaveException() { }
       // public UnableToSaveException(string message) : base(message) { }
        public UnableToSaveException(string message=null, Exception innerException=null) : base(message, innerException) { }
    }
    class CalculatorRepository//DAL - Data Access Layer
    {

        public static void Save(string input)
        {
            File.WriteAllText("calculator.txt",input);
        }
    }
}
