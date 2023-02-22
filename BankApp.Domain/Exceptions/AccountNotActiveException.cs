﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Exceptions
{
    public class AccountNotActiveException:ApplicationException
    {
        public AccountNotActiveException(string msg,Exception e=null):base(msg,e) { }
    }
}
