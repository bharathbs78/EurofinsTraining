using AIRecommendationEngine.CoreRecommender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Recommender.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        List<int> baseData;
        List<int> otherData;
        IRecommender recommender;
        [TestInitialize]
        public void Init()
        {
           recommender = new PearsonRecommender();
        }
        [TestCleanup]
        public void Cleanup()
        {
            recommender = null;
        }
        [TestMethod]
        public void RecommenderTest_BothEqualLengthNonZero_ShouldReturnCoefficient()
        {
            baseData = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            otherData = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.That(recommender.GetCorrelation(baseData, otherData),Is.InRange(-1.0,1.0));

        }
        [TestMethod]
        public void RecommenderTest_BaseLengthLessNonZeroInputs_ShouldReturnCoefficient()
        {
            baseData = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            otherData = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double coefficient=recommender.GetCorrelation(baseData,otherData);
            Assert.AreEqual(baseData.Count, otherData.Count);
            Assert.That(coefficient, Is.InRange(-1.0, 1.0));
        }
        [TestMethod]
        public void RecommenderTest_OtherLengthLessNonZero_ShouldReturnCoefficient()
        {
            baseData = new List<int> { 1, 2, 3, 4, 5, 6, 7, 10, 9 };
            otherData = new List<int> { 1, 2, 3, 4, 5, 6 };
            double coefficient = recommender.GetCorrelation(baseData, otherData);
            Assert.AreEqual(baseData.Count, otherData.Count);
            Assert.That(coefficient, Is.InRange(-1.0, 1.0));

        }
        [TestMethod]
        public void RecommenderTest_LengthEqualZero_ShouldReturnCoefficient()
        {
            baseData = new List<int> { 1, 2, 3, 0, 5, 0, 7, 8, 10 };
            otherData = new List<int> { 1, 2, 3, 10, 5, 6,0,0,0 };
            double coefficient = recommender.GetCorrelation(baseData, otherData);
            Assert.IsTrue(!baseData.Contains(0));
            Assert.IsTrue(!otherData.Contains(0));
            Assert.That(coefficient, Is.InRange(-1.0, 1.0));

        }
    }
}
