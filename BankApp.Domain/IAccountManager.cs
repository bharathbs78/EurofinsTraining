using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public interface IAccountManager
    {
        void OpenAccount(Account account);
        void CloseAccount(Account account);
        void Withdraw(Account account,double amount,int pin);
        void Deposit(Account account, double amount);
        void TransferAmount(Account sender, Account receiver,double amount,int pin);
    }
}
