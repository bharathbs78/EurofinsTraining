using Recommender.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommender.UI
{
    public class recommenderConsoleApp
    {
        static void Main(string[] args)
        {
            IRecommender recommender=new PearsonRecommender();
            List<int> baseList= new List<int>();
            List<int> otherList= new List<int>();
            for(int i = 0; i < 10; i++)
            {
                baseList.Add(i+1);
                otherList.Add(-i-1);
            }
            Console.WriteLine(recommender.GetCorrelation(baseList, otherList));
        }
    }
}
