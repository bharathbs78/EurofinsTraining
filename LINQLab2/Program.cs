using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument doc=XDocument.Load("XMLFile1.xml");
            //Console.WriteLine(doc);
            Console.WriteLine("all names");
            var xml=from d in doc.Descendants("Employees").Descendants("Employee").Elements("Name") select d.Value;
            foreach(var x in xml)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            Console.WriteLine("Employee name and Id");
            var xml1 = from d in doc.Descendants("Employee") select
                       new
                       {
                           Name = d.Element("Name").Value,
                           Id = d.Element("EmpId").Value
                       };
            foreach(var x in xml1)
            {
                Console.WriteLine(x.Name+" "+x.Id);
            }
            Console.WriteLine();
            Console.WriteLine("Female Employees Only");
            xml = null;
            xml=from d in doc.Descendants("Employee") where d.Element("Sex").Value.Equals("Female") select d.Element("Name").Value;
            foreach(var x in xml)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            Console.WriteLine("All Home Phone Numbers");
            xml = from d in doc.Descendants("Employee") where d.Element("Phone").Attribute("Type").Value.Equals("Home") select d.Element("Phone").Value;
            foreach (var x in xml)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            Console.WriteLine("7");
            var xm = from d in doc.Descendants("Employee") orderby d.Element("Address").Element("Zip").Value select d;
            foreach (var x in xm)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            Console.WriteLine("First 2 employees");
            var first = doc.Descendants("Employee").ToList().GetRange(0,2);
            foreach (var x in first)
            {
                Console.WriteLine(x);
            }
            var count=doc.Descendants("Employee").Count(d => d.Element("Address").Element("State").Value.Equals("CA")) ;
            Console.WriteLine(count);
            Console.WriteLine();
            Console.WriteLine("Female employee details");
            var something=from d in doc.Descendants("Employee") where d.Element("Sex").Value.Equals("Female") select new
            {
                Name = d.Element("Name").Value,
                City = d.Element("Address").Element("City").Value,
                Gender = d.Element("Sex").Value
            };
            foreach (var x in something)
            {
                Console.WriteLine("Name: "+x.Name+" City :"+x.City+" Gender :"+x.Gender);
            }
        }
    }
}
