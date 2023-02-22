using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Exceptions
{
    public class InvalidPinException:ApplicationException
    {
        public InvalidPinException(string msg,Exception innerException=null) : base(msg, innerException)
        {

        }
    }
}
