using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExercises
{
    internal class Part6
    {
        static void Main(string[] args)
        {
            SavingsAccount account = new SavingsAccount(12345, 2000);
            try
            {
                account.Withdraw(2500);
            }
            catch (OverdrawnException ex) { Console.WriteLine(ex.Message); }
        }
    }
    class SavingsAccount
    {
        private int accountNumber;
        private double balance;
        public SavingsAccount(int accountNumber,double balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }
        public void Withdraw(double amount)
        {
            if (balance - amount >= 0)
                balance -= amount;
            else throw new OverdrawnException("Insufficient Balance", balance);
        }
    }
    class OverdrawnException : ApplicationException
    {
        public OverdrawnException(string message,double balance) : base(message + balance)
        {

        }
    }
}
