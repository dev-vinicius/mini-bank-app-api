namespace MiniBankApp.Domain.Events.Contracts
{
    public interface IEventHandler<T> where T : class
    {
        Task HandleAsync(T @event);
    }
}
