using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Exceptions
{
    public class AccountAlreadyClosedException:ApplicationException
    {
        public AccountAlreadyClosedException(string message,Exception e=null) : base(message,e) { }
    }
}
