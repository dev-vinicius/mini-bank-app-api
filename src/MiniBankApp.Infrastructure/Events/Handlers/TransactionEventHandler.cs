using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Transactions;

namespace MiniBankApp.Infrastructure.Events.Handlers
{
    public class TransactionEventHandler : IEventHandler<TransactionEvent>
    {
        public async Task HandleAsync(TransactionEvent @event)
        {
            Console.WriteLine($"[TransactionProcessed] Transação: {@event.Id} | Valor: {@event.Value}");
            await Task.CompletedTask;
        }
    }
}
