using System;
using System.Numerics;
using SecondApp.Interfaces;
using Fibonacci;
using Microsoft.Extensions.Logging;

namespace SecondApp.Utilits
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IFibonacciCalculator _fibonacciCalculator;
        private readonly ILogger<RequestHandler> _logger;
        public RequestHandler(IFibonacciCalculator fibCalculator, ILogger<RequestHandler> logger)
        {
            _fibonacciCalculator = fibCalculator;
            _logger = logger;
        }

        public BigInteger ProcessRequest(string message)
        {
            try
            {
                _logger.LogInformation("Processing the request");
                _logger.LogDebug($"Number is: {message}");

                return _fibonacciCalculator.GetNextNumber(BigInteger.Parse(message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process request");
                throw;
            }
            
        }
    }
}
