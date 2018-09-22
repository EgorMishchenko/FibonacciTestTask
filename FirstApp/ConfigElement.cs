using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    public static class ConfigElement
    {
        public static string SecondAppAddress { get { return "SecondAppAddress"; }  }
        public static string Host { get { return "Host"; } }
        public static string QueueName { get { return "QueueName"; } }
        public static string RabbitMQLogin { get { return "RabbitMQLogin"; } }
        public static string RabbitMQPassword { get { return "RabbitMQPassword"; } }
        public static string RabbitMQHostUrl { get { return "RabbitMQHostUrl"; } }
    }
}
