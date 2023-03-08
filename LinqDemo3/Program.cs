using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xml= XDocument.Load("XMLFile1.xml");
            XElement doc = new XElement("books",
                 from b in xml.Descendants("book")
                 where b.Element("genre").Value.Equals("Fantasy")
                 select new XElement("book",
                 new XAttribute("id", b.Attribute("id").Value),
                 new XElement("title", b.Element("title").Value),
                 new XElement("author", b.Element("author").Value)));
            doc.Save("FantasyBooks.xml");
            //doc.ToList().ForEach(f => Console.WriteLine(f.title+" "+f.id+" "+f.author));
        }
    }
}
