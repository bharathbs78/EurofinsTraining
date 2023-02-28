using AIRecommendationEngine.Common.Entities;
using AIRecommendationEngine.Integrator;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recommendation recommendation=new Recommendation();
            Console.WriteLine("Enter ISBN");
            string ISBN=Console.ReadLine();
            Console.WriteLine("Enter State");
            string state=Console.ReadLine();
            Console.WriteLine("Enter age");
            int age=int.Parse(Console.ReadLine());
            Preference preference = new Preference
            {
                ISBN = ISBN,
                Age = age,
                State = state
            };
            List<Book> list=recommendation.Recommend(preference, 10);
            foreach(Book book in list)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
