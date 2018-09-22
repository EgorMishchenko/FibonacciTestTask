using System;
using Fibonacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci.Exceptions;

namespace FibonacciTests
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void GetNextNumberTest()
        {
            var fibonacciCalc = new FibonacciCalculator();

            var result0 = fibonacciCalc.GetNextNumber(0);
            Assert.AreEqual(1, result0);

            var result1 = fibonacciCalc.GetNextNumber(1);
            Assert.AreEqual(1, result1);

            var result2 = fibonacciCalc.GetNextNumber(1);
            Assert.AreEqual(2, result2);

            var result3 = fibonacciCalc.GetNextNumber(2);
            Assert.AreEqual(3, result3);

            var result4 = fibonacciCalc.GetNextNumber(3);
            Assert.AreEqual(5, result4);

            var result5 = fibonacciCalc.GetNextNumber(5);
            Assert.AreEqual(8, result5);
        }

        [TestMethod]
        public void GetNumberWithoutPrevious()
        {
            var fibonacciCalc = new FibonacciCalculator();
            Assert.ThrowsException<OutOfFibonacciSequenceException>(() => fibonacciCalc.GetNextNumber(13));
        }

        [TestMethod]
        public void GetNexNumberForNegative()
        {
            var fibonacciCalc = new FibonacciCalculator();

            var result0 = fibonacciCalc.GetNextNumber(0);
            Assert.AreEqual(1, result0);

            Assert.ThrowsException<OutOfFibonacciSequenceException>(() => fibonacciCalc.GetNextNumber(-1));
        }
    }
}
