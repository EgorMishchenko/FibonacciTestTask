using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondApp.Interfaces;

namespace SecondApp.Controllers
{
    [Produces("application/json")]
    [Route("api/fibonacci")]
    public class FibonacciController : Controller
    {
        private readonly IRequestHandler _requestProcessor;
        private readonly IRabbitSender _rabbitSender;
        private readonly ILogger<FibonacciController> _logger;

        public FibonacciController(IRequestHandler requestProcessor, IRabbitSender rabbitSender, ILogger<FibonacciController> logger)
        {
            _requestProcessor = requestProcessor;
            _rabbitSender = rabbitSender;
            _logger = logger;
        }

        [Route("{number}")]
        [HttpGet]
        public void GetNextNumber(string number)
        {
            try
            {
                _logger.LogInformation("Procesing the request");
                var processedNumber = _requestProcessor.ProcessRequest(number);

                _logger.LogDebug("Sending message to bus");
                _rabbitSender.SendMessage(processedNumber.ToString());

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed to process the request");
                throw; 
            }
            
        }
    }
}
