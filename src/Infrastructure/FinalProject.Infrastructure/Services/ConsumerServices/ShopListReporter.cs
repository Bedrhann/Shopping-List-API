using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace FinalProject.Infrastructure.Services.ConsumerServices
{
    public class ShopListReporter : IHostedService, IDisposable
    {
        private readonly IShopListCommandArchiveRepository _archiveRepository;

        public ShopListReporter(IShopListCommandArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
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
        public async Task Work(object asd)
        {
            IConnection connection = GetConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare("fanout.shoplist", false, false, true);
            EventingBasicConsumer basicConsumer = new EventingBasicConsumer(channel);
            basicConsumer.Received += async (sender, args) =>
            {
                ShopListArchiveDto shopList = JsonSerializer.Deserialize<ShopListArchiveDto>(Encoding.UTF8.GetString(args.Body.ToArray()));
                await _archiveRepository.SendCompletedShopList(shopList);
                await _archiveRepository.SaveAsync();
                File.AppendAllText(@"E:\DotNetWork\UserRegistration.txt", shopList.Name + shopList.Description + " Date:" + DateTime.Now.ToString() + "\n");
            };
            channel.BasicConsume("fanout.shoplist", false, basicConsumer);
        }

        public void Dispose()
        {

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Work(null);
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("error: Watching Stopped");
            return Task.CompletedTask;
        }
    }
}
