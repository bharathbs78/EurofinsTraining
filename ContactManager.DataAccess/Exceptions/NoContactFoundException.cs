using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Exceptions
{
    class NoContactFoundException:ApplicationException
    {
        public NoContactFoundException(string message) : base(message)
        {

        }
    }
}
