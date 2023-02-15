using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Company
    {
        public string Name { get; set; }    
        public DateTime IncorporatedDt { get; set; }
        public Branch Corporate { get; set; }
        public Branch Registered { get; set; }
        public List<Branch> Branches { get; set; }= new List<Branch>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Customer> Customers { get; set; }=new List<Customer>();
        public Employee GetEmployee(int id)
        {
            foreach(var emp in Employees)
            {
                if(emp.EmpId==id)
                    return emp;
            }
            return null;
        }
        public double GetTotalSalaryPayout()
        {
            double total = 0;
            foreach (var emp in Employees)
                total += emp.GetSalary();
            return total;
        }
        public int GetTotalCustomers()
        {
            return Customers.Count;
        }
        public int GetTotalEmployees()
        {
            return Employees.Count;
        }
    }
    class Branch
    {

    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
    class Employee:Person
    {
        public int EmpId { get; set; }
        public double Basic { get; set; }
        public double Experience { get; set; }
        public virtual double GetSalary()
        {
            return Basic + SalaryCalculator.CalculateSalary(Experience, Basic);
        }
    }
    class Customer:Person
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
    }
    class SalaryCalculator
    {
        public static double CalculateSalary(double experience,double basic)
        {
            double allowancePer = 0;
            if (experience <= 2)
                allowancePer = 0.3;
            else if (experience <= 4)
                allowancePer = 0.4;
            else if (experience <= 6)
                allowancePer = 0.5;
            else
                allowancePer = 0.65;
            return basic * allowancePer;
        }
    }
}
