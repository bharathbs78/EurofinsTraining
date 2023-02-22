using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimpleCalculatorLibrary;
namespace SimpleCalculator.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult()
        {
            int fno = 10;
            int sno = 20;
            int expected = 30;
            Calculator calculator = new Calculator();
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
            Calculator calculator = new Calculator();
            calculator.Sum(-1, -2);
        }
        [TestMethod]
        [ExpectedException(typeof(OddNumberException))]
        public void Sum_WithOddInput_ShouldThrowException()
        {
            Calculator calculator = new Calculator();
            calculator.Sum(1,3);
        }
    }
}
