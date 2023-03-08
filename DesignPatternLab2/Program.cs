using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICostCalculator bulkCalc=new CostCalculator();
            BulkDiscounter bulkDiscounter = new BulkDiscounter(bulkCalc);
            Console.WriteLine(bulkDiscounter.CalculateCost(new List<Item> {
                new Item
                {
                    Cost=100,
                    Qty=1
                },
                new Item
                {
                    Cost=10,
                    Qty=2
                }
            })
            ) ;
            NewDiscounter newDiscounter= new NewDiscounter(bulkCalc);
            Console.WriteLine(newDiscounter.CalculateCost(new List<Item> {
                new Item
                {
                    Cost=100,
                    Qty=1
                },
                new Item
                {
                    Cost=10,
                    Qty=2
                }
            })
);
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Qty { get; set; }
    }

    public interface ICostCalculator
    {
        double CalculateCost(List<Item> items);
    }
    public class CostCalculator : ICostCalculator
    {
        public double CalculateCost(List<Item> items)
        {
            return items.Sum(item => item.Cost * item.Qty);
        }
    }
    public abstract class Discounter : ICostCalculator
    {
        public ICostCalculator calculator = null;
         public Discounter(ICostCalculator calculator)
        {
            this.calculator= calculator;
        }
        public virtual double CalculateCost(List<Item> items)
        {
            if (calculator != null)
                return calculator.CalculateCost(items); 
            else 
                return 0;

        }
    }
    
    public class BulkDiscounter : Discounter
    {
        public BulkDiscounter(ICostCalculator c) : base(c) { }
        public override double CalculateCost(List<Item> items)
        {
            double total=base.CalculateCost(items);
            
            return total-50;
        }
    }
    public class NewDiscounter : Discounter
    {
        public NewDiscounter(ICostCalculator c) : base(c) { }
        public override double CalculateCost(List<Item> items)
        {
            double total=base.CalculateCost(items);
            return total-100;
        }
    }
}
