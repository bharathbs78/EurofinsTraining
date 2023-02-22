using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Exceptions
{
    internal class CannotSaveContactException:ApplicationException
    {
        public CannotSaveContactException(string message,Exception innerException) : base(message,innerException) { }
    }
}
