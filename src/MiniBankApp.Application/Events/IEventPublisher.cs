namespace MiniBankApp.Application.Events
{
    public interface IEventPublisher
    {
        public Task PublishAsync<T>(T @event) where T : class;
    }
}
