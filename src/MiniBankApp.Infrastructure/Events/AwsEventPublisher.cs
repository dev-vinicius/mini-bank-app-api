using MiniBankApp.Application.Events;
using System.Text.Json;

namespace MiniBankApp.Infrastructure.Events
{
    internal class AwsEventPublisher : IEventPublisher
    {
        public async Task PublishAsync<T>(T @event) where T : class
        {
            //faz envio para AWS ou RabbitMQ etc...
            await Task.Delay(1);
            Console.WriteLine($"Event name: {@event.GetType().Name}");
            Console.WriteLine($"Event data: {JsonSerializer.Serialize(@event)}"); 
        }
    }
}
