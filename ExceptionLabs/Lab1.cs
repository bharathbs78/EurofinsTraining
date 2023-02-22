using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ExceptionLabs
{
    internal class Lab1
    {
        static void Main(string[] args)
        {
            try
            {
                long number = long.Parse(Console.ReadLine());
                validate(number);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void validate(long num)
        {
            if (num.ToString().Length != 10)
                throw new InvalidContactNumberException("Contact Length is not equal to 10");
            else if (!num.ToString().StartsWith("9"))
                throw new InvalidContactNumberException("Contact Number doesn't begin with 9");
        }
    }
    class InvalidContactNumberException : ApplicationException
    {
        public InvalidContactNumberException(string message):base(message) { }
    }
}
