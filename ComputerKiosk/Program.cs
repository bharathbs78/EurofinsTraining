using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerKiosk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch;
            while (true)
            {
                Admin admin=new Admin();
                Console.WriteLine("a - Admin Login");
                Console.WriteLine("n - Create a new Customer");
                Console.WriteLine("e - Existing CustomerLogin");
                Console.WriteLine("s - Search");
                Console.WriteLine("x - Quit");
                Console.Write("Enter your option:");
                ch=char.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 'a':
                        new Admin().AdminLogin();
                        break;
                    case 'n':
                        Customer customer=new Customer();
                        break;
                    case 'e':
                        break;
                        
                }
            }
        }
    }
    class Computer
    {
        public int Id { get; set; }
        public string type { get; set; }
        public double CPUSpeed { get; set; }
        public double Capacity { get; set; }
        public string GraphicsCard { get; set; }
        public double price { get; set; }
    }
    class Laptop : Computer
    {
        public double weight { get; set; }
        public double BatteryDuration { get; set; }

    }
    class Desktop : Computer
    {
        public double MonitorSize { get; set; }
    }
    class Customer:Details
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string password { get;set; }
        public void placeOrder()
        {

        }
        public void Login(int id,string password)
        {
            if(this.Id==id && this.password==password)
                Console.WriteLine("Login Successful");
        }
    }
    class Details { 
        public string Name { get; set; }
        public int age { get; set; }
        public string Gender { get; set; }
    }
    class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Computer Computer { get; set; }
        public Status status { get; set; }
    }
    enum Status
    {
        PENDING = 0,
        DELIVERED=1
    }
    class Admin : Details
    {
        public int Id { get; set; } = 4321;
        public string Password { get; set; } = "a";
        public List<Order> orders { get; set; } = new List<Order>() ;
        public void addComputer()
        {

        }
        public string AdminLogin()
        {
            Console.Write("Enter Login ID:");
            if (int.Parse(Console.ReadLine()) == Id)
            {
                Console.WriteLine("Enter password");
                if (Console.ReadLine() == Password)
                {
                    return "Admin Authenticated";
                }
                return "Wrong Password";
            }
            return "Wrong Admin ID";
        }
        public void processOrder()
        {


        }
    }

}
