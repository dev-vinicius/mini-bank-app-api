using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts;
using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;
using MiniBankApp.Infrastructure.DataAccess;
using MiniBankApp.Infrastructure.UseCases.Accounts.GetAll;
using MiniBankApp.Infrastructure.UseCases.Accounts.GetById;
using MiniBankApp.Infrastructure.UseCases.Accounts.Register;
using MiniBankApp.Infrastructure.UseCases.Transactions.Credit;
using MiniBankApp.Infrastructure.UseCases.Transactions.Debit;
using MiniBankApp.Infrastructure.UseCases.Transactions.History;
using MiniBankApp.Infrastructure.UseCases.Transactions.Transfer;

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
            builder.Services.AddScoped<ITransactionDebitRepository, TransactionDebitRepository>();
            builder.Services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            builder.Services.AddScoped<ITransactionTransferRepository, TransactionTransferRepository>();
            builder.Services.AddScoped<IGetAllAccountsRepository, GetAllAccountsRepository>();
        }
    }
}
