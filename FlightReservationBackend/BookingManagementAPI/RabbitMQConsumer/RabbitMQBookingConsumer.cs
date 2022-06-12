using BookingManagementAPI.Models;
using BookingManagementAPI.Repository;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingManagementAPI.RabbitMQConsumer
{
    public class RabbitMQBookingConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly BookingRepository _bookingRepository;

        public RabbitMQBookingConsumer(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "bookingqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                BookingDetailsDto bookingDetailsDto = JsonConvert.DeserializeObject<BookingDetailsDto>(content);
                HandleMessage(bookingDetailsDto).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("bookingqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(BookingDetailsDto bookingDetailsDto)
        {
            var _response = await _bookingRepository.BookFlight(bookingDetailsDto);
        }
    }
}
