using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data
{
    public interface IAccountRepository
    {
        void RecordTransaction(int SenderAccNo, int ReceiverAccNo, double amount, DateTime transactionDate);
        int GetTransactionCount(int AccNo,DateTime date);
    }
}
