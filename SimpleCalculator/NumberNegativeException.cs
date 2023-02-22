using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class NumberNegativeException:ApplicationException
    {
        public NumberNegativeException(string msg,Exception inner = null):base(msg,inner) { }
    }
}
