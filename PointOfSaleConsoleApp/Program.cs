using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CalculatorFactory f1 = CalculatorFactory.Instance;
            //CalculatorFactory f2 = CalculatorFactory.Instance;
            //Console.WriteLine($"f1 : {f1.GetHashCode()}");
            //Console.WriteLine($"f2 : {f2.GetHashCode()}");
            BillingSystem billingSystem = new BillingSystem();
            billingSystem.GenerateBill();
        }
    }
    public class CalculatorFactory
    {
        public static readonly CalculatorFactory Instance = new CalculatorFactory();
        private CalculatorFactory()
        {

        }
        //public static CalculatorFactory GetInstance()
        //{
        //    if(instance==null)
        //        instance=new CalculatorFactory();
        //    return instance;
        //}
        public virtual ITaxCalculator CreateTaxCalculator()
        {
            string className= ConfigurationManager.AppSettings["TaxCalc"];
            Type type=Type.GetType(className);
            ITaxCalculator taxCalc=(ITaxCalculator)Activator.CreateInstance(type);
            return taxCalc;
        }
    }
    public class BillingSystem
    {
        private ITaxCalculator tax = null;
        public  void GenerateBill()
        {
            //scan
            double amount = 6500.90;
            //discount
            double discount = 125;
            //offers
            //tax
            CalculatorFactory calculatorFactory= CalculatorFactory.Instance;
            tax=calculatorFactory.CreateTaxCalculator();
            double taxAmt = tax.CalculateTax(amount);
            //print bill
            double totAmt = amount - discount + taxAmt;
            //payments
            Console.WriteLine(totAmt);
        }
    }
    public interface ITaxCalculator   //Strategy
    {
        double CalculateTax(double amount); 
    }
    class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            double ct = 125.67;
            double kst = 56.89;
            double es = 50.00;
            double sbt = 23;
            double kkt = 20;
            double tax = ct + kst + es + sbt + kkt;
            Console.WriteLine("KA Tax Calculator");
            return tax;
        }
    }
    class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            double at = 125.67;
            double tnst = 56.89;
            double ks = 50.00;
            double sbt = 23;
            double kkt = 20;
            double tax = at + tnst + ks + sbt + kkt;
            Console.WriteLine("KA Tax Calculator");
            return tax; 
        }
    }
    public class USTaxCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public float ComputeTax(float amount)
        {
            double st = 1005.67;
            double sert = 56.89;
            double ks = 50.00;
            double sbt = 23;
            double kkt = 20;
            float tax = (float)(st + sert + ks + sbt + kkt);
            Console.WriteLine("US Tax Calculator");
            return tax;
        }
    }//Assume this code is not yours and you only have the dll then
    public class USTaxCalculatorAdapter : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            USTaxCalculator calc = new USTaxCalculator();
            return calc.ComputeTax((float)amount);
        }
    }
}
