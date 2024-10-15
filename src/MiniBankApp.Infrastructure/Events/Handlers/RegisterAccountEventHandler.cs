using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Accounts;

namespace MiniBankApp.Infrastructure.Events.Handlers
{
    public class RegisterAccountEventHandler : IEventHandler<RegisterAccountEvent>
    {
        public async Task HandleAsync(RegisterAccountEvent @event)
        {
            Console.WriteLine($"[AccountCreated] Conta criada: {@event.Name} (ID: {@event.Id})");
            await Task.CompletedTask;
        }
    }
}
