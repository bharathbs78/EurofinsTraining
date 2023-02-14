using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode1
{
    internal class Program// class has-a, method uses
    {
        //has a changes the state(structure) of a class and changes the size of the object.
        //Customer customer1=new Customer(); //program and customer has an Has-A relationship
        static void Main(string[] args)
        {
            Customer customer=new Customer();//uses relationship - single use only // Consumer 
            //uses does not change the original size and structure of the program.
            customer.Name = "Test";
            customer.Id = 1;
            customer.Age = 1;
            Console.WriteLine(customer.Age);
            Employee e = new Employee { EmpId=1 };//faster and easier
            Employee e1 = new Employee { EmpId = 1, Name = "test1" };
            Employee e2 = new Employee { Name="test2" };
            Employee e3 = new Employee { Salary = 1000 };
            Employee employee = new Employee { EmpId = 1, Name = "test", Salary = 50000,
                Address = new Address { Area = "Brookefield",
                    City = "Bengaluru",
                    State = "Karnataka",
                    Country = "India" } };
            Address address= new Address { Area="Brookefield"};
            customer.Address = address;
        }
    }
    //use properties instead of get and set
    class Customer // Author
    {
        private int id; //default private
        public int Id
        {
            get { return id; }
            set { id = value; }//value is a built in variable that stores the assigned value.
        }
        public string Name
        {
            get;// Automatic property
            set;
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if(age<18 || age>60)
                    age = 18;
                age = value;
            }
        }
        public Address Address { get; set; }

    }
    class Employee// if validation required
    {
      /* public Employee(int id,string name,int salary): this(id,name) //ctor + tab+ tab // constuctor chaining
        {
           // EmpId = id;
            Name = name;
            Salary = salary;
        }
        public Employee(int id)
        {
            EmpId = id;
        }
        public Employee(int id,string name) : this(id)
        {
            Name= name;
        }*/

        public int EmpId { get; set; }
        public string Name { get; set; }
        private int salary;
        public int Salary { 
            get {
                return salary; 
            }
            set {
                if (value < 10000)
                    salary = 10000;
                 salary=value; 
            } 
        }
        public Address Address { get; set; }
    }
    class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
