namespace MiniBankApp.Domain.Repositories;

public interface IUnityOfWork
{
    Task CommitAsync();
}