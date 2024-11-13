using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories;

public class UnityOfWork(MiniBankAppDbContext context) : IUnityOfWork
{
    public async Task CommitAsync() => await context.SaveChangesAsync();
}