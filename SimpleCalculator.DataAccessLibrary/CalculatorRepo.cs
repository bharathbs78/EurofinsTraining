using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.DataAccessLibrary
{
    public class CalculatorRepo
    {
        public bool Save(string data)
        {
            File.WriteAllText("X:\\calculatedresult.txt", data);
            return true;
        }
    }
}
