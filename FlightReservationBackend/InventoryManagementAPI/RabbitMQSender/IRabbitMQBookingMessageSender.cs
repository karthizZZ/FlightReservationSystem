using InventoryManagementAPI.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.RabbitMQSender
{
    public interface IRabbitMQBookingMessageSender
    {
        void SendMessage(BaseMessage message, String queueName);
    }
}
