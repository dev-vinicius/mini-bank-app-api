using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiniBankApp.Application.UseCases.Accounts.GetById;
using MiniBankApp.Application.UseCases.Accounts.Register;
using MiniBankApp.Application.UseCases.Transactions.Credit;
using MiniBankApp.Infrastructure.DataAccess;
using MiniBankApp.Infrastructure.UseCases.Accounts.GetById;
using MiniBankApp.Infrastructure.UseCases.Accounts.Register;
using MiniBankApp.Infrastructure.UseCases.Transactions.Credit;

namespace MiniBankApp.Infrastructure.Extensions
{
    public static class RegisterDependenciesExtension
    {
        public static void RegisterInfrastructureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MiniBankAppDbContext>();
            builder.Services.AddScoped<IGetAccountByIdRepository, GetAccountByIdRepository>();
            builder.Services.AddScoped<IRegisterAccountRepository, RegisterAccountRepository>();
            builder.Services.AddScoped<ITransactionCreditRepository, TransactionCreditRepository>();
        }
    }
}
