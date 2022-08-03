using FinalProject.Application.Interfaces.Services.RabbitMQService;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FinalProject.Infrastructure.Services.EventService
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private IConnection GetConnection()
        {
            return new ConnectionFactory()
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            }.CreateConnection();
        }

        public void Publish(object obj, string queue)
        {
            using IConnection connection = GetConnection();
            using IModel channel = connection.CreateModel();
            //channel.ExchangeDeclare("fana.basic", ExchangeType.Fanout, false, false);

            channel.QueueDeclare(queue, false, false, true);

            //channel.QueueBind(queue, "fana.basic", string.Empty);
            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
            channel.BasicPublish("", queue, body: messageBody);
        }

    }
}
