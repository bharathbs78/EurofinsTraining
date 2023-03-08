using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("XMLFile1.xml");
            var shortWords = from x in xml.Descendants("word") where x.Value.Length<=3 select x.Value;
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
