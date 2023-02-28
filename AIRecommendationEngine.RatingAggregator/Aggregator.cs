using AIRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.RatingAggregator
{
    public class Aggregator : IAggregator
    {
        public Dictionary<string, List<int>> Aggregate(BookDetails bookDetails, Preference preference)
        {
            Dictionary<string,List<int>> aggregate= new Dictionary<string,List<int>>();
            foreach(var rating in bookDetails.BookUsersRatings)
            {
                if (rating.user.State.Equals(preference.State))
                {
                    if (isSameAgeGroup(rating.user.Age, preference.Age))
                    {
                        if(!aggregate.ContainsKey(rating.ISBN))
                            aggregate.Add(rating.ISBN,new List<int> { rating.Rating });
                        else
                            aggregate[rating.ISBN].Add(rating.Rating);
                    }

                }
            }
            return aggregate;
        }
        private static bool isSameAgeGroup(int age1,int age2)
        {
            int prevage = 0;

            foreach (var age in Enum.GetValues(typeof(ageGroup)))
            {
                int presentage = (int)age;
                if ((age1 > prevage && age1 <= presentage) && (age2 > prevage && age2 <= presentage))
                    return true;
                prevage = presentage;
            }
            return false;
        }
        private enum ageGroup
        {
            TeenAge=16,
            YoungAge=30,
            MidAge=50,
            OldAge=60,
            SeniorCitizen=100
        }
    }
}
