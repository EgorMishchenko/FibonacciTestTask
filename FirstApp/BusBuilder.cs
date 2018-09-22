using System;
using EasyNetQ;

namespace FirstApp
{
    public class BusBuilder
    {
        public static IBus CreateMessageBus()
        {
            var address = ConfigurationHelper.GetValueByKey("Host");

            if (address == null || address == string.Empty)
            {
                throw new Exception("easynetq connection string is missing or empty");
            }

            return RabbitHutch.CreateBus(address);
        }
    }
}
