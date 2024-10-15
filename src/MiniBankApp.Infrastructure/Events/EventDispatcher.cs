using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Accounts;
using MiniBankApp.Domain.Events.EventData.Transactions;
using MiniBankApp.Infrastructure.Events.Implementations;

namespace MiniBankApp.Infrastructure.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly Dictionary<Type, object> _eventHandlers;

        public EventDispatcher()
        {
            _eventHandlers = new Dictionary<Type, object>
        {
            { typeof(RegisterAccountEvent), new AccountCreatedEventHandler() },
            { typeof(TransactionEvent), new TransactionProcessedEventHandler() }
        };
        }

        public async Task DispatchAsync<T>(T @event) where T : class
        {
            if (_eventHandlers.TryGetValue(typeof(T), out var handler))
            {
                var eventHandler = handler as IEventHandler<T>;
                if (eventHandler != null)
                {
                    await eventHandler.HandleAsync(@event);
                }
            }
            else
            {
                throw new InvalidOperationException($"Nenhum handler registrado para o evento do tipo {typeof(T).Name}");
            }
        }
    }
}
