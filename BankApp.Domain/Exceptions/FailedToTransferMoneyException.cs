using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Exceptions
{
    internal class FailedToTransferMoneyException:ApplicationException
    {
        public FailedToTransferMoneyException(string message,Exception e) : base(message,e) { }
    }
}
