using AIRecommendationEngine.Common.Entities;
using AIRecommendationEngine.Loader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataLoaderTest
{

    [TestClass]
    public class UnitTest1
    {
        IDataLoader loader;
        [TestMethod]
        public void TestMethod1()
        {
            loader=new CSVLoader();
            BookDetails bookDetails=loader.Load();
            Assert.AreEqual(9999, bookDetails.Users.Count);
        }
    }
}
