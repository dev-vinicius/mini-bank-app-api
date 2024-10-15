using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Transactions;

namespace MiniBankApp.Infrastructure.Events.Implementations
{
    public class TransactionProcessedEventHandler : IEventHandler<TransactionEvent>
    {
        public async Task HandleAsync(TransactionEvent @event)
        {
            // Lógica para tratar o evento
            Console.WriteLine($"[TransactionProcessed] Transação: {@event.Id} | Valor: {@event.Value}");
            await Task.CompletedTask; // Simulação de operação assíncrona
        }
    }
}
