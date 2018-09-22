using EasyNetQ;
using SecondApp.Interfaces;
using Microsoft.Extensions.Logging;

namespace SecondApp.Utilits
{
    public class RabbitSender : IRabbitSender
    {
        private readonly IBus _bus;
        private readonly ILogger<RabbitSender> _logger;
        public RabbitSender(IBus bus, ILogger<RabbitSender> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public void SendMessage(string message)
        {
            _logger.LogInformation("Sending message");
            _bus.Publish(message);
        }
    }
}
