using System;
using RestSharp;
using FirstApp.Interfaces;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FirstApp
{
    public class RestMessageSender : IRestMessageSender
    {
        private readonly ILogger<RestMessageSender> _logger;
        public RestMessageSender(ILogger<RestMessageSender> logger)
        {
            _logger = logger;
        }
        public async Task<RestRequest> SendMessage(BigInteger number)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(ConfigurationHelper.GetValueByKey(ConfigElement.SecondAppAddress));

            var requestBody = number.ToString();
            _logger.LogDebug($"Request body:{requestBody}");
            
            var request = new RestRequest(requestBody, Method.GET);

            _logger.LogInformation($"Sending request");
            await client.ExecuteGetTaskAsync(request); 

            return request;
        }
    }
}
