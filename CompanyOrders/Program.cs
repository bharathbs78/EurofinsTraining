using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item item1= new Item { Rate=100};
            Item item2= new Item { Rate=76.4};
            Item item3= new Item { Rate=65.34};
            Item item4= new Item { Rate=99.99};
            Item item5= new Item { Rate= 65};
            Item item6= new Item { Rate=32};
            OrderedItem orderedItem1= new OrderedItem  { Item = item1, Qty=2};
            OrderedItem orderedItem2 = new OrderedItem { Item = item2, Qty=4};
            OrderedItem orderedItem3 = new OrderedItem { Item = item3, Qty=10};
            OrderedItem orderedItem4 = new OrderedItem { Item = item4, Qty=1};
            OrderedItem orderedItem5 = new OrderedItem { Item = item5, Qty=1};
            OrderedItem orderedItem6 = new OrderedItem { Item = item6, Qty=6};
            Order order1= new Order ();
            Order order2= new Order ();
            Order order3= new Order ();
            order1.OrderedItems.Add (orderedItem1);
            order1.OrderedItems.Add (orderedItem2);
            order2.OrderedItems.Add (orderedItem3);
            order2.OrderedItems.Add (orderedItem4);
            order3.OrderedItems.Add (orderedItem5);
            order3.OrderedItems.Add(orderedItem6);
            Customer customer1=new Customer ();
            RegCustomer customer2 = new RegCustomer();
            customer2.SplDiscount = 20;
            customer1.Orders.Add(order1);
            customer1.Orders.Add(order2);
            customer2.Orders.Add(order3);
            Company company=new Company ();
            company.Customers.Add (customer1);
            company.Customers.Add (customer2);
            Console.WriteLine($"Total {company.GetTotalWorthOfOrdersPlaced()}");
        }
    }
    class Company
    {
        public List<Item> Items { get; set; }= new List<Item>();
        public List<Customer> Customers { get; set; }=new List<Customer>();
        public double GetTotalWorthOfOrdersPlaced()
        {
            double totalWorthOfOrdersPlaced = 0.0;
            foreach(var customer in Customers)
            {
                totalWorthOfOrdersPlaced += customer.GetTotalWorth();
            /*    double customerTotal = 0.0;
                foreach(var order in customer.Orders)
                {
                    foreach (var ordereditem in order.OrderedItems)
                    {
                        customerTotal += ordereditem.Qty * ordereditem.Item.Rate;
                    }
                }
                if(customer is RegCustomer regCustomer)//type - casting customer to regCustomer
                {
                    //RegCustomer regCustomer=(RegCustomer) customer; // downcasting
                    //RegCustomer regCustomer=customer as RegCustomer;
                    customerTotal *= ((100-regCustomer.SplDiscount)/100);
                }
                totalWorthOfOrdersPlaced += customerTotal;
                customerTotal = 0.0;*/
            }
            return totalWorthOfOrdersPlaced;
        }

    }
    class Item
    {
        public string Desc { get; set; }
        public double Rate { get; set; }
    }
    class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public virtual double GetTotalWorth()
        {
            double total = 0.0;
            foreach(Order order in this.Orders)
            {
                total += order.GetTotalWorth();
            }
            return total;
        }
    }
    class RegCustomer : Customer
    {
        public double SplDiscount { get; set; }
        public override double GetTotalWorth()
        {
            double total = 0.0;
            foreach (Order order in this.Orders)
            {
                total += order.GetTotalWorth();
            }
            return total*((100-SplDiscount)/100);
        }
    }
    class Order
    {
        public Customer Customer { get; set; }
        public List<OrderedItem> OrderedItems { get; set; }=new List<OrderedItem>();
        public double GetTotalWorth()
        {
            double total = 0;
            foreach (var orderitem in OrderedItems)
                total += orderitem.GetTotalWorth();
            return total;
        }
    }
    class OrderedItem
    {
        public Item Item { get; set; }
        public int Qty { get; set; }

        public double GetTotalWorth()
        {
            return Item.Rate* Qty;
        }
    }
}