using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public class Account
    {
        public int Accno { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }
        public bool isActive { get; set; } = false;
        public string OpeningDate { get; set; } = null;
        public string CloseDate { get; set; } = null;

    }
}
