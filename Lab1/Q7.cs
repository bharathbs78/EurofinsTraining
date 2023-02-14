using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q7
    {
        static void Main(string[] args)
        {
            string name,empid;
            double basic, splAllow, bonusPer, taxSavMonthly, gross, net, tax, bonus, grossM;
            double taxableIncome,paid=0;
            Console.Write("Enter name and empid");
            name = Console.ReadLine();
            empid = Console.ReadLine();
            Console.Write("Enter basic , allow, bonus %,monthly tax savings");
            basic=int.Parse(Console.ReadLine());
            splAllow=int.Parse(Console.ReadLine());
            bonusPer=int.Parse(Console.ReadLine()); 
            taxSavMonthly=int.Parse(Console.ReadLine());
            grossM = basic + splAllow;
            bonus = bonusPer * basic * 12 / 100;
            gross = 12 * grossM+bonus;
            double annualTaxSav = 12 * taxSavMonthly;
            if (gross > 100000)
            {
                if (annualTaxSav < 100000)
                    taxableIncome = gross - annualTaxSav;
                else
                    taxableIncome = gross - 100000;
                if (taxableIncome >= 150000)
                    paid = (taxableIncome - 150000) * 0.3 + 10000;
                else if (taxableIncome > 100000)
                    paid = (taxableIncome - 100000) * 0.2;
            }
            net = gross - paid;
            Console.WriteLine($"gross {gross}");
            Console.WriteLine($"net {net}");
            Console.WriteLine($"tax paid {paid}");
        }
    }
}
