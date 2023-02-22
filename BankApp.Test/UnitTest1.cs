using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using BankApp.Data;
using Notification;
using BankApp.Domain;

namespace BankApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IAccountManager _accountManager;
        private Mock<INotification> notification;
        private Mock<IAccountRepository> accountRepository;
        [TestInitialize]
        public void Init()
        {
            notification= new Mock<INotification>();
            notification.Setup(n => n.SendMessage("Some Message"));
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
    }
}
