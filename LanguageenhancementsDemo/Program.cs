using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEnhancementsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data type determined during compile time.
            var a = 10;
            //a = "ten";// strongly typed so will give error
            var str = "new string";
            var keyValuePairs = new Dictionary<int, List<int>>();
            //object x = 10;
            //x = "10";
            //object y = "ten"; // not strongly typed
            var p = new 
            {
                Name = "something",
                Id = 1,
                Rate = 10000
            }; 
        }
        
    }
    //public class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public double Rate { get; set; }
    //}
}
