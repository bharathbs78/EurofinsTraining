using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAccountCalculator accountCalculator=AccountCalculatorFactory.Instance.GetAccountCalculator();
            Console.WriteLine(accountCalculator.CalculateInterest(1000,1));
        }
    }
    public interface IAccountCalculator
    {
        double CalculateInterest(double amount,double duration);
    }
    public class SavingsAccountCalculator : IAccountCalculator
    {
        public double CalculateInterest(double amount, double duration)
        {
            double interest = 0.12;
            return amount* interest*duration;
        }
    }
    public class FDAccountCalculator : IAccountCalculator
    {
        public double CalculateInterest(double amount, double duration)
        {
            throw new NotImplementedException();
        }
    }
    public class AccountCalculatorFactory
    {
        public static readonly AccountCalculatorFactory Instance = new AccountCalculatorFactory();
        public IAccountCalculator GetAccountCalculator()
        {
            string acc = ConfigurationManager.AppSettings["account"];
            Type type = Type.GetType(acc);
            return (IAccountCalculator) Activator.CreateInstance(type);
        }

    }
}
