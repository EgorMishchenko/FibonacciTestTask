using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using Fibonacci;
using SecondApp.Utilits;
using Moq;

namespace SecondAppTests
{
    [TestClass]
    public class RequestHandlerTests
    {
        private readonly Mock<IFibonacciCalculator> _fibonacciCalculator = new Mock<IFibonacciCalculator>();
        private readonly ILogger<RequestHandler> _logger;

        [TestInitialize]
        public void TestInitialization()
        {
            _fibonacciCalculator.Setup(x => x.GetNextNumber(new BigInteger(1))).Returns(new BigInteger(2));
            _fibonacciCalculator.Setup(x => x.GetNextNumber(new BigInteger(2))).Returns(new BigInteger(3));
        }

        [TestMethod]
        public void TestMethod1()
        {
            var requestHandler = new RequestHandler(_fibonacciCalculator.Object, Mock.Of<ILogger<RequestHandler>>());

            var bigIntegerTwo = new BigInteger(2);
            Assert.AreEqual(bigIntegerTwo, requestHandler.ProcessRequest("1"));

            var bigIntegerThree = new BigInteger(3);
            Assert.AreEqual(bigIntegerThree, requestHandler.ProcessRequest("2"));
        }
    }
}
