using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;
using MiniBankApp.Infrastructure.Events;
using MiniBankApp.Infrastructure.Repositories;

namespace MiniBankApp.Infrastructure.Extensions
{
    public static class RegisterDependenciesExtension
    {
        public static void RegisterInfrastructureServices(this WebApplicationBuilder builder)
        {
            //database
            builder.Services.AddDbContext<MiniBankAppDbContext>();
            builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            //events
            builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();
        }
    }
}
