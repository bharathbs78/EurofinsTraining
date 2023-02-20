using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaleItem item = new SaleItem { des="Monitor", rate=7000 };
            SaleItem item2 = new SaleItem { des = "Hard disk", rate = 5500 };
            Sale sale1 = new Sale(item,2,5);
            Sale sale2 = new Sale(item2, 5, 10);
            SaleList list = new SaleList
            {
                DtSale = new DateTime(2016,3,16),
                CustName="Jennifer"
            };
            list.add(sale1);
            list.add(sale2);
            BillingSys sys = new BillingSys();
            sys.generateBill(list);
        }
    }
    class SaleItem
    {
        public double rate { get; set; }
        public string des { get; set; }
        public SaleItem()
        {

        }
        public SaleItem(string des, double rate)
        {
            this.des = des;
            this.rate = rate;
        }
    }
    class Sale
    {
        public int qty { get; set; }
        public double disc { get; set; }
        public SaleItem saleItem { get; set; }
        public Sale()
        {

        }
        public Sale(SaleItem item,int qty, double disc)
        {
            this.saleItem=item;
            this.qty = qty;
            this.disc = disc;
        }
    }
    class SaleList
    {
        public DateTime DtSale { get; set; }
        public string CustName { get; set; }
        public LinkedList<Sale> Sales { get; set; } = new LinkedList<Sale>();
        public void add(Sale sale)
        {
            Sales.AddLast(sale);
        }
    }
    class BillingSys
    {
        public StdTaxCalc std;
        public BillingSys()
        {
        }
        public void generateBill(SaleList saleList)
        {
            double grandTotal = 0;
            TaxCalcFactory t=TaxCalcFactory.instance;

            grandTotal = saleList.Sales.Sum(s => s.qty * s.saleItem.rate * s.disc / 100) *(1- t.create().getIst()) *(1- t.create().getFedTax() );
            Console.WriteLine(grandTotal);
        }
    }
    sealed class TaxCalcFactory
    {
        private TaxCalcFactory() 
        {

        }
        private static TaxCalcFactory _instance=null;
        public static TaxCalcFactory instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TaxCalcFactory();
                return _instance;
            }
        }
        public StdTaxCalc create()
        {
            return new StdTaxCalc();
        }
    }
    class StdTaxCalc
    {
        public double getIst()
        {
            return 0.1;
        }
        public double getFedTax()
        {
            return 0.015;
        }
    }
}
