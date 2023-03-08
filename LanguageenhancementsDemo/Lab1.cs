using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LanguageEnhancementsDemo
{
    class Lab1
    {
        static void Main(string[] args, bool indexExpression)
        {
            var products=ProductsDB.GetProducts();
            //1. List all products whose price in between 50K to 80K
            Console.WriteLine("Products in range of 50k to 80k");
            (from p in products where p.Price >= 50000 && p.Price <= 80000 select p).ToList().ForEach(p => Console.WriteLine(p.Name)); ;
            //2. Extract all products belongs to Laptops catagory
            products.Where(p => p.Catagory.Name.Equals("Laptops")).ToList().ForEach(p => Console.WriteLine(p.Name));
            //3. Extract/Show Product Name and Catagory Name only
            var productCatagory = from p in products select new
            {
                Category=p.Catagory.Name,
                p.Name
            };
            foreach(var p in productCatagory)
            {
                Console.WriteLine(p.Name+" "+p.Category);
            }
            //4. Show the costliest product name 
            Console.WriteLine(products.Select(p => p).OrderByDescending(p => p.Price).First().Name);
            Console.WriteLine(products.Find(p => p.Price==products.Max(p1=>p1.Price)).Name);
            //5. Show the cheepest product name and its price
            Console.WriteLine(products.Select(p => p).OrderByDescending(p => p.Price).Last().Name);
            Console.WriteLine(products.Select(p => p).Min().Name);
            //6. Show the 2nd and 3rd product details
            //IndexExpression indexExpression=new IndexExpression(products);
            //from p in products where indexExpression==2 || indexExpression==3 select p.Name
            //7. List all products in assending order of their price
            //8. Count the no. of products belong to Tablets
            //9. Show which catagory has costly product
            //10. Show which catagory has less products

            //11. Extract the Product Details based on the catagory and show as below

            //Laptops
            //  Dell XPS 13
            //  HP 430
            //Mobiles
            //    IPhone 6
            //    Galaxy S6
            //Tablets
            //    IPad Pro
            //12. Extract the Product count based on the catagory and show as below

            //Laptops : 2
            //Mobiles: 2
            //Tablets: 1

        }

    }
    class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
            Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
            Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

            Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
            Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
            Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
            Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
            Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

            cat1.Products.Add(p1);
            cat1.Products.Add(p2);
            cat2.Products.Add(p3);
            cat2.Products.Add(p4);
            cat3.Products.Add(p5);

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}





