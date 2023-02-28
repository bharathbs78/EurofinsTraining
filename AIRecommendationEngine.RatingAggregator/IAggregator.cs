using AIRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.RatingAggregator
{
    public interface IAggregator
    {
        Dictionary<string, List<int>> Aggregate(BookDetails bookDetails, Preference preference);
    }
}
