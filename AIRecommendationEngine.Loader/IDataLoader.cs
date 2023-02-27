using AIRecommendationEngine.Loader.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Loader
{
    public interface IDataLoader
    {
        BookDetails Load();
    }
}
