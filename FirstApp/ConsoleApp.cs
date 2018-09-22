using System;
using Microsoft.Extensions.Logging;
using FirstApp.Interfaces;
using EasyNetQ.Management.Client;

namespace FirstApp
{
    public class ConsoleApp
    {
        private readonly ILogger<ConsoleApp> _logger;
        private readonly IRestMessageSender _restSender;
        private readonly IRabbitReciever _rabbitReciever;

        public ConsoleApp(ILogger<ConsoleApp> logger, IRestMessageSender restSender, IRabbitReciever rabbitReciever)
        {
            _logger = logger;
            _restSender = restSender;
            _rabbitReciever = rabbitReciever;
        }

        public void Run()
        {
            try
            {
                _logger.LogInformation("Application run");

                int threadsNumbers = 0;
                Console.WriteLine("Please, enter number of threads: ");
                Int32.TryParse(Console.ReadLine(), out threadsNumbers);

                if (threadsNumbers == 0) threadsNumbers++;

                Console.WriteLine("Press Enter when the SecondApp is ready");

                _logger.LogInformation($"Application runs in {threadsNumbers} threads");

                StartTransition(_restSender, threadsNumbers);

                _rabbitReciever.SubscribeMessage();

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Uncaught exception occured");
            }
            finally
            {
                try
                {
                    _logger.LogInformation("Purge queue");
                    var login = ConfigurationHelper.GetValueByKey(ConfigElement.RabbitMQLogin);
                    var password = ConfigurationHelper.GetValueByKey(ConfigElement.RabbitMQPassword);

                    var client = new ManagementClient(ConfigElement.RabbitMQHostUrl, login, password);
                    var vhost = client.GetVhostAsync("/");
                    vhost.Wait();

                    var task = client.GetQueueAsync(ConfigurationHelper.GetValueByKey(ConfigElement.QueueName), vhost.Result);
                    task.Wait();

                    client.PurgeAsync(task.Result);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex, "Uncaught exception occured");
                }
            }
        }

        private static void StartTransition(IRestMessageSender sender, int threads)
        {
            for (int i = 0; i < threads; i++)
            {
                sender.SendMessage(0);
            }
        }
    }
}
