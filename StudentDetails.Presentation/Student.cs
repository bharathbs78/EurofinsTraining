using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranker;
namespace StudentDetails.Presentation
{
    internal class Student
    {
        static void Main(string[] args)
        {
            int[] scores = new int[3];
            string name;
            Console.Write("Enter Student's name");
            name=Console.ReadLine();
            Console.WriteLine("Enter Marks");
            for(int i=0;i<scores.Length;i++)

            {
                Console.Write($"Subject{i} = ");
                scores[i] = int.Parse(Console.ReadLine());
            }
            FindRank student = new FindRank();
            Console.WriteLine(student.AddScores(scores));
            Console.WriteLine(student.ScoresAvg(scores));
            Console.WriteLine(student.Rank(student.ScoresAvg(scores)));
        }
    }
}
