using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;
using MiniBankApp.Infrastructure.Events;
using MiniBankApp.Infrastructure.Repositories.Accounts.GetAll;
using MiniBankApp.Infrastructure.Repositories.Accounts.GetById;
using MiniBankApp.Infrastructure.Repositories.Accounts.Register;
using MiniBankApp.Infrastructure.Repositories.Transactions.Credit;
using MiniBankApp.Infrastructure.Repositories.Transactions.Debit;
using MiniBankApp.Infrastructure.Repositories.Transactions.History;
using MiniBankApp.Infrastructure.Repositories.Transactions.Transfer;

namespace MiniBankApp.Infrastructure.Extensions
{
    public static class RegisterDependenciesExtension
    {
        public static void RegisterInfrastructureServices(this WebApplicationBuilder builder)
        {
            //database
            builder.Services.AddDbContext<MiniBankAppDbContext>();
            builder.Services.AddScoped<IGetAccountByIdRepository, GetAccountByIdRepository>();
            builder.Services.AddScoped<IRegisterAccountRepository, RegisterAccountRepository>();
            builder.Services.AddScoped<ITransactionCreditRepository, TransactionCreditRepository>();
            builder.Services.AddScoped<ITransactionDebitRepository, TransactionDebitRepository>();
            builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            builder.Services.AddScoped<ITransactionTransferRepository, TransactionTransferRepository>();
            builder.Services.AddScoped<IGetAllAccountsRepository, GetAllAccountsRepository>();


            //events
            builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();
        }
    }
}
