using AIRecommendationEngine.Common.Entities;
using AIRecommendationEngine.Loader;
using AIRecommendationEngine.RatingAggregator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIRecommendatioEngine.RatingAggregatorTest
{
    [TestClass]
    public class UnitTest1
    {
        BookDetails bookDetails;
        IAggregator aggregator;
        Preference preference;
        IDataLoader loader;
        [TestInitialize]
        public void init()
        {
            loader=new CSVLoader();
            preference = new Preference
            {
                State = "kansas",
                Age = 71
            };
            bookDetails = loader.Load();
            aggregator=new Aggregator();
        }
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<string,List<int>> dict=aggregator.Aggregate(bookDetails, preference);
            //Assert.IsTrue(dict.Count!=0);
            Assert.AreEqual(23,dict.Count);
        }
    }
}
