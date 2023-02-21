using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Exceptions
{
    internal class ContactCannotBeEditedException:ApplicationException
    {
        public ContactCannotBeEditedException(string message,Exception e):base(message,e) { }
    }
}
