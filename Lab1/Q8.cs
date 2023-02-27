using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Q8
    {
        static void Main(string[] args)
        {
            double totHrs = 0.0;
            double ratePerHr = 0.0;
            char hasExternalConsultants = 'N';
            double consHrs = 0.0;
            double consRatePerHr = 0.0;
            char hasHwInfra = 'N';
            double hwInfraCosts = 0.0;
            char hasSoftwareLic = 'N';
            double swLicCosts = 0.0;
            char freqType = 'R';
            double projCost = 0.0;
            double swCost = 0.0;
            double profits = 0.0;

            Console.WriteLine("Enter total hours worked:");
            totHrs = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter rate per hour:");
            ratePerHr = double.Parse(Console.ReadLine());

            Console.WriteLine("Does the project involve external consultants? (Y/N)");
            hasExternalConsultants = char.Parse(Console.ReadLine());

            if (hasExternalConsultants == 'y' || hasExternalConsultants == 'Y')
            {
                Console.WriteLine("Enter the hours worked by consultants:");
                consHrs = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the rate per hour for consultants:");
                consRatePerHr = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Does the project require hardware infrastructure? (Y/N)");
            hasHwInfra = char.Parse(Console.ReadLine());

            if (hasHwInfra == 'y' || hasHwInfra == 'Y')
            {
                Console.WriteLine("Enter the cost of hardware infrastructure:");
                hwInfraCosts = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Does the project require software licensing? (Y/N)");
            hasSoftwareLic = char.Parse(Console.ReadLine());

            if (hasSoftwareLic == 'y' || hasSoftwareLic == 'Y')
            {
                Console.WriteLine("Enter the cost of software licensing:");
                swLicCosts = double.Parse(Console.ReadLine());
            }

            projCost = totHrs * ratePerHr;
            projCost += hwInfraCosts * 0.3;

            if (freqType == 'C')
            {
                swCost = 0.5 * swLicCosts;
            }
            else if (freqType == 'R')
            {
                swCost = swLicCosts;
            }

            projCost += swCost;

            Console.WriteLine("Project cost: " + projCost);

            profits = projCost - (consHrs * consRatePerHr + hwInfraCosts + swLicCosts);
            Console.WriteLine("Profits: " + profits);

            if (profits > 0)
            {
                Console.WriteLine("Profitable");
            }
            else
            {
                Console.WriteLine("Incurs a loss");
            }
        }
    }
}
