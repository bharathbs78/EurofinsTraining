using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BankSuccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface IDepositable
    {
        bool Deposit(double amount);
    }
    interface IWithdrawable
    {
        bool Withdraw(double amount);
    }
    interface IInterestCalculator
    {
        double CalculateInterest(Account anAccount);
    }
    abstract class Account:IDepositable
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public int MonthsHeld { get; set; }
        public Customer Customer { get; set; }
        public IInterestCalculator InterestCalculator { get; set; }

        public abstract double CalculateInterest();
        public Type GetCustomerType()
        {
            return Customer.GetType();
        }

        public bool Deposit(double amount) { return true; }
    }
    abstract class Customer
    {
    }
    class Bank
    {
        public List<Account> accounts { get; set; }=new List<Account>();
    }
    class Savings :  Account,IWithdrawable
    {
        public override double CalculateInterest()
        {
            return InterestCalculator.CalculateInterest(this);
        }
        public bool Withdraw(double amount)
        {
            return amount<=this.Balance;
        }
    }
    class Loan : Account
    {
        public override double CalculateInterest()
        {
            return InterestCalculator.CalculateInterest(this);
        }
    }
    class Motgage : Account
    {
        public override double CalculateInterest()
        {
            return InterestCalculator.CalculateInterest(this);
        }
    }
    class LoanIndividualInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            if (anAccount.MonthsHeld > 3)
            {
                return (anAccount.MonthsHeld - 3) * anAccount.InterestRate;
            }
            else
                return 0;
        }
    }
    class MortgageIndividualInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            if (anAccount.MonthsHeld > 6)
                return (anAccount.MonthsHeld - 6) * anAccount.InterestRate;
            else
                return 0;
        }
    }
    class SavingsInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            if (anAccount.Balance < 1000 && anAccount.Balance > 0)
                return 0.0;
            else
                return anAccount.InterestRate*anAccount.MonthsHeld;
        }
    }
    class LoanCompanyInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount) 
        {
            if (anAccount.MonthsHeld > 2)
                return (anAccount.MonthsHeld - 2) * anAccount.InterestRate;
            else
                return 0;
        }
    }
    class MortgageCompanyInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount) 
        {
            if (anAccount.MonthsHeld > 12)
                return (anAccount.MonthsHeld - 12) * anAccount.InterestRate + 12 * anAccount.InterestRate / 2;
            else
                return anAccount.InterestRate / 2 * anAccount.MonthsHeld;
        }
    }
    class Individual : Customer
    {

    }
    class Company : Customer
    {

    }
}
