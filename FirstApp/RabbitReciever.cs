using System;
using System.Numerics;
using EasyNetQ;
using Fibonacci;
using FirstApp.Interfaces;
using Microsoft.Extensions.Logging;

namespace FirstApp
{
    public class RabbitReciever : IRabbitReciever
    {
        private readonly IFibonacciCalculator _fibonacciCalculator;
        private readonly IRestMessageSender _restMessageSender;
        private readonly IBus _bus;
        private readonly ILogger<RabbitReciever> _logger;
        public RabbitReciever(IFibonacciCalculator fibonacciCalculator, IRestMessageSender restSender, IBus bus, ILogger<RabbitReciever> logger)
        {
            _fibonacciCalculator = fibonacciCalculator;
            _restMessageSender = restSender;
            _bus = bus;
            _logger = logger;
        }
        public void SubscribeMessage()
        {
            var queueName = ConfigurationHelper.GetValueByKey(ConfigElement.QueueName);
            var result = _bus.Subscribe<string>(queueName, HandleMessage);
        }
        public void HandleMessage(string message)
        {
            _logger.LogInformation($"Current number is {message}");

            try
            {
                var result = _fibonacciCalculator.GetNextNumber(BigInteger.Parse(message));

                _logger.LogDebug($"Next number is {message}");
                _restMessageSender.SendMessage(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception calculating next Fibonacci number");
                throw;
            }
        }
    }
}
