using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Accounts;

namespace MiniBankApp.Infrastructure.Events.Implementations
{
    public class AccountCreatedEventHandler : IEventHandler<RegisterAccountEvent>
    {
        public async Task HandleAsync(RegisterAccountEvent @event)
        {
            // Lógica para tratar o evento
            Console.WriteLine($"[AccountCreated] Conta criada: {@event.Name} (ID: {@event.Id})");
            await Task.CompletedTask; // Simulação de operação assíncrona
        }
    }
}
