using RabbitMQ.Client;

namespace FinalProject.Application.Interfaces.Services.RabbitMQService
{
    public interface IRabbitMqPublisher
    {
        void Publish(object obj, string queue);
    }
}
