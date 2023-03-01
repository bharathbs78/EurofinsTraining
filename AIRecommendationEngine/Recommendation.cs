using AIRecommendationEngine.Common.Entities;
using AIRecommendationEngine.CoreRecommender;
using AIRecommendationEngine.Loader;
using AIRecommendationEngine.RatingAggregator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Integrator
{
    public class Recommendation
    {
        IRecommender recommender;
        IAggregator aggregator;
        IDataLoader dataLoader;
        /// <summary>
        /// Recommends limit number of books
        /// </summary>
        /// <param name="preference"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Book> Recommend(Preference preference,int limit)
        {
            recommender = new PearsonRecommender();
            aggregator= new Aggregator();
            dataLoader = new CSVLoader();
            BookDetails bookDetails = dataLoader.Load();
            Dictionary<string, List<int>> dict = aggregator.Aggregate(bookDetails, preference);
            List<int> baseData;
            if (dict.ContainsKey(preference.ISBN))
            {
                baseData= dict[preference.ISBN];
            }
            else
            {
                baseData= new List<int> { 10,10,10,10,10,10,10,10,10,10};
                //Random random= new Random();
                //baseData = new List<int>();
                //for(int i = 0; i < random.Next(25); i++)
                //{
                //    baseData.Add(random.Next(10));
                //}
            }
            dict =dict.Where(d => d.Value.Count > 0).ToDictionary(d => d.Key,d => d.Value);
            Dictionary<string, double> recommendations = new Dictionary<string, double>();
            foreach(var key in dict.Keys)
            {
                if (key != preference.ISBN)
                {
                    int[] otherData = new int[dict[key].Count()];
                    dict[key].CopyTo(otherData, 0);
                    recommendations.Add(key,recommender.GetCorrelation(baseData, otherData.ToList()));
                }
            }
            List<KeyValuePair<string, double>> recommendList = recommendations.ToList();
            recommendList.Sort((kp, kp1) =>
            {
                return kp1.Value.CompareTo(kp.Value);
            });
            List<Book> books= new List<Book>(); 
            for(int i = 0; i < limit && i<recommendList.Count; i++)
            {
                books.Add(bookDetails.Books.Find(b => b.ISBN.Equals(recommendList[i].Key)));
            }
            return books;
        }
    }
}
