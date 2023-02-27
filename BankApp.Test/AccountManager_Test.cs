using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using BankApp.Data;
using Notification;
using BankApp.Domain;
using BankApp.Domain.Exceptions;

namespace BankApp.Test
{
    [TestClass]
    public class AccountManager_Test
    {
        private IAccountManager _accountManager;
        private Mock<INotification> notification;
        private Mock<IAccountRepository> accountRepository;
        [TestInitialize]
        public void Init()
        {
            notification= new Mock<INotification>();
            notification.Setup(n => n.SendMessage("Deposited"));
            accountRepository= new Mock<IAccountRepository>();
            accountRepository.Setup(a => a.RecordTransaction(1234, 4321, 10000, DateTime.Now));
            accountRepository.Setup(a => a.GetTransactionCount(1234, DateTime.Now)).Returns(1);
            _accountManager = new AccountManager(notification.Object,accountRepository.Object); 
        }
        [TestCleanup]
        public void Clean()
        {
            notification = null;
            accountRepository= null;
        }
        [TestMethod]
        public void AccountManager_AccountOpenSuccessful()
        {
           Account account=new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
            };
            _accountManager.OpenAccount(account);
            Assert.IsNotNull(account.OpeningDate);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyOpenException))]
        public void AccountManager_AccountAlreadyOpened_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
            };
            _accountManager.OpenAccount(account);
            _accountManager.OpenAccount(account);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotActiveException))]
        public void AccountManager_DepositMadeAccountNotOpened_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
            };
            _accountManager.Deposit(account, 10000);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotActiveException))]
        public void AccountManager_DepositMadeAccountClosed_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
            };
            _accountManager.OpenAccount(account);
            _accountManager.CloseAccount(account);
            _accountManager.Deposit(account, 10000);
        }
        [TestMethod]
        public void AccountManager_ValidDeposit_ShouldGiveNotification()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
            };
            _accountManager.OpenAccount(account);
            _accountManager.Deposit(account, 10000);
            notification.Verify(n=>n.SendMessage("Deposited"),Times.Once());
        }
        [TestMethod]
        public void AccountManager_ValidWithdraw_ShouldGiveNotification()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
                Pin = 1111
            };
            _accountManager.OpenAccount(account);
            _accountManager.Deposit(account, 10000);
            _accountManager.Withdraw(account, 5000,1111);
            notification.Verify(n => n.SendMessage("Deposited"), Times.AtLeastOnce());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidPinException))]
        public void AccountManager_InvalidPinForWithdraw_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 10000,
                Pin = 11112
            };
            _accountManager.OpenAccount(account);
            _accountManager.Withdraw(account, 5000, 1111);
        }
        [TestMethod]
        [ExpectedException(typeof(InsufficientBalanceException))]
        public void AccountManager_InvalidBalanceForWithdraw_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 0,
                Pin = 1111
            };
            _accountManager.OpenAccount(account);
            _accountManager.Withdraw(account, 5000, 1111);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotActiveException))]
        public void AccountManager_AccountNotActiveForForWithdraw_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 10000,
                Pin = 1111
            };
            _accountManager.Withdraw(account, 5000, 1111);
        }
        [TestMethod]
        public void AccountManager_AccountCannotCloseInvalidBalance_ShouldThrowException()
        {
            Account account = new Account
            {
                Accno = 1234,
                Name = "bha",
                Balance = 10000,
                Pin = 1111
            };
            _accountManager.OpenAccount(account);
            Assert.ThrowsException<AccountCannotBeClosedException>(() => _accountManager.CloseAccount(account));
        }

    }

}
