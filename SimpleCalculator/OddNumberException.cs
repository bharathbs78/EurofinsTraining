using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class OddNumberException:ApplicationException
    {
        public OddNumberException(string msg, Exception innerException = null) : base(msg, innerException) { }
    }
}
