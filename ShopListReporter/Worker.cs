using FinalProject.Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ShopListReporter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
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
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using IConnection connection = GetConnection();
                using IModel channel = connection.CreateModel();
                channel.QueueDeclare("bu.deneme", false, false, true);
                EventingBasicConsumer basicConsumer = new EventingBasicConsumer(channel);
                basicConsumer.Received += (sender, args) =>
                {
                    ShopList shopList = JsonSerializer.Deserialize<ShopList>(Encoding.UTF8.GetString(args.Body.ToArray()));
                    Console.WriteLine(shopList.Description + " :********************** " + DateTime.Now);
                    Console.WriteLine();
                };
                channel.BasicConsume("bu.deneme", false, basicConsumer);
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //await Task.Delay(1000, stoppingToken);
            }
        }
    }
}