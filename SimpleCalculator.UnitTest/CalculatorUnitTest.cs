using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimpleCalculatorLibrary;
using SimpleCalculator.DataAccessLibrary;
using Moq;

namespace SimpleCalculator.UnitTest
{
    //class MockCalculatorRepo : ICalculatorRepo
    //{
    //    public bool Save(string msg)
    //    {
    //        return true;
    //    }
    //}
    //MOQ,StructureMap,nInject
    [TestClass]
    public class CalculatorUnitTest
    {
        private Calculator calculator = null;
        Mock<ICalculatorRepo> mock = null;
        [TestInitialize] // for every test case this method runs before the test case
        public void Init()
        {
            mock = new Mock<ICalculatorRepo>();
            mock.Setup(m=>m.Save("30")).Returns(true);
            calculator= new Calculator(mock.Object);
        }
        [TestCleanup]
        public void Cleanup()
        {
            calculator = null;
            mock = null;
        }
        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult()
        {
            int fno = 10;
            int sno = 20;
            int expected = 30;
           // Calculator calculator = new Calculator(repo);
            int actual=calculator.Sum(fno, sno);
            Assert.AreEqual(expected,actual);
            //don't use conditional statements
            //don't use try...catch blocks
            //don't iterative statements
            //AAA 
            //Arrange - Arrange stage based on scenario
            //Act - Act on the target
            //Assert - test the functionality
        }
        [TestMethod]
        [ExpectedException(typeof(NumberNegativeException))]
        public void Sum_WithNegativeInput_ShouldThrowException()
        {
            //Calculator calculator = new Calculator(repo);
            calculator.Sum(-1, -2);
        }
        [TestMethod]
        [ExpectedException(typeof(OddNumberException))]
        public void Sum_WithOddInput_ShouldThrowException()
        {
            //Calculator calculator = new Calculator(repo);
            calculator.Sum(1,3);
        }
        [TestMethod]
        public void Sum_WithValidInput_ShouldCallSave()// very difficult to do manually
        {
            calculator.Sum(10, 20);
            mock.Verify(m => m.Save("30"),Times.Once());
        }
    }
}
