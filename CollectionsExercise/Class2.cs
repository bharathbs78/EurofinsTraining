using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExercise
{
    internal class Class2
    {
        static void Main(string[] args)
        {
            List<Entity> Products= new List<Entity>();
            Products.Add(new Entity {ProductId=200,BrandName="Dell",Description="15 inch Monitor",Price=3400.44 });
            Products.Add(new Entity { ProductId = 120, BrandName = "Dell", Description = "Laptop", Price = 45000.00 });
            Products.Add(new Entity { ProductId = 150, BrandName = "Microsoft", Description = "Windows 7", Price = 7000.50 });
            Products.Add(new Entity { ProductId = 100, BrandName = "Logitech", Description = "Optical Mouse", Price = 540.00 });
            Products.Sort((e1,e2)=>e1.ProductId.CompareTo(e2.ProductId));
            Products.ForEach(e => { Console.WriteLine(e.ProductId + " " + e.BrandName + " " + e.Description + " " + e.Price); });
            Console.WriteLine("Select option 1 for sort by brand name and 2 for sort by price");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Products.Sort((e1,e2)=>e1.BrandName.CompareTo(e2.BrandName));
                    Products.ForEach(e => { Console.WriteLine(e.ProductId + " " + e.BrandName + " " + e.Description + " " + e.Price); });
                    break;
                case 2:
                    Products.Sort((e1, e2) => e1.Price.CompareTo(e2.Price));
                    Products.ForEach(e => { Console.WriteLine(e.ProductId + " " + e.BrandName + " " + e.Description + " " + e.Price); });
                    break;
                default:
                    Products.ForEach(e => { Console.WriteLine(e.ProductId + " " + e.BrandName + " " + e.Description + " " + e.Price); });
                    break;
            }
        }
        
    }
    class Entity
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
