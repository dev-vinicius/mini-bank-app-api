namespace MiniBankApp.Domain.Events.Contracts
{
    public interface IEventDispatcher
    {
        public Task DispatchAsync<T>(T @event) where T : class;
    }
}
