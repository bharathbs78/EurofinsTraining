using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Exceptions
{
    internal class AccountNotOpenedException:ApplicationException
    {
        public AccountNotOpenedException(string msg,Exception e=null):base(msg,e) { }
    }
}
