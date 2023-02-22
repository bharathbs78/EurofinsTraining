using BankApp.Data;
using BankApp.Domain.Exceptions;
using Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public class AccountManager : IAccountManager
    {
        private INotification notification = null;
        private IAccountRepository accountRepository = null;
        public AccountManager(INotification notification, IAccountRepository accountRepository)
        {
            this.notification = notification;
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// closes account
        /// </summary>
        /// <param name="account"></param>
        /// <exception cref="AccountCannotBeClosedException"></exception>
        public void CloseAccount(Account account)
        {
            if (account.isActive != true)
                throw new AccountCannotBeClosedException("Cannot close account",new AccountNotActiveException("Account is not active(maybe closed already/ not activated yet)"));
            if (account.Balance > 0.0)
                throw new AccountCannotBeClosedException("Account should have 0 balance to close");
            account.CloseDate = DateTime.Now.ToString();
            account.isActive = false;
        }
        /// <summary>
        /// deposits money to account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <exception cref="AccountNotActiveException"></exception>

        public void Deposit(Account account, double amount)
        {
            if (!account.isActive)
                throw new AccountNotActiveException("Account is not yet activated / already closed");
            account.Balance += amount;
            notification.SendMessage("Deposited");
        }
        /// <summary>
        /// opens an account
        /// </summary>
        /// <param name="account"></param>
        /// <exception cref="AccountNotOpenedException"></exception>
        public void OpenAccount(Account account)
        {
            if(account.OpeningDate!=null)
                throw new AccountAlreadyOpenException("Account is already Opened");
            account.OpeningDate = DateTime.Now.ToString();
            account.isActive= true;
        }
        /// <summary>
        /// transfers amount from sender to receiver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="amount"></param>
        /// <param name="pin"></param>
        /// <exception cref="FailedToTransferMoneyException"></exception>
        public void TransferAmount(Account sender, Account receiver, double amount,int pin)
        {
            if (accountRepository.GetTransactionCount(sender.Accno, DateTime.Now) < 3)
            {
                Withdraw(sender, amount, pin);
                try
                {
                    Deposit(receiver, amount);
                    accountRepository.RecordTransaction(sender.Accno, receiver.Accno, amount, DateTime.Now);
                    notification.SendMessage("Transfer successful");

                }
                catch (Exception ex)
                {
                    Deposit(sender, amount);
                    throw new FailedToTransferMoneyException("Money transfer Failed", ex);
                }
            }
            else
                throw new DailyTransactionLimitReachedException("Try tomorrow");
        }
        /// <summary>
        /// Withdraws money from account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <param name="pin"></param>
        /// <exception cref="AccountNotActiveException"></exception>
        /// <exception cref="InvalidPinException"></exception>
        /// <exception cref="InsufficientBalanceException"></exception>
        public void Withdraw(Account account, double amount,int pin)
        {
            if (!account.isActive)
                throw new AccountNotActiveException("Account closed/ not yet activated");
            if (account.Pin != pin)
                throw new InvalidPinException("Wrong pin entered");
            if (account.Balance < amount)
                throw new InsufficientBalanceException("Balance Insufficient");
            account.Balance -= amount;
            notification.SendMessage("Deposited");
        }
    }
}
