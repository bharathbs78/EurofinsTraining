using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Business
{
    public class Calculator// should be public not internal
    {
        public static int FindSum(int fno,int sno)
        {
            return fno + sno;
        }
    }
}
