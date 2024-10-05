using MiniBankApp.Application.Configuration;
using MiniBankApp.Application.UseCases.Accounts.GetAll;
using MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts;
using MiniBankApp.Application.UseCases.Accounts.GetById;
using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
using MiniBankApp.Application.UseCases.Accounts.Register;
using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Credit;
using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Debit;
using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.History;
using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Transfer;
using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;

namespace MiniBankApp.Api.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.Database.ConnectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void AddUseCases(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGetAccountByIdUseCase, GetAccountByIdUseCase>();
            builder.Services.AddScoped<IRegisterAccountUseCase, RegisterAccountUseCase>();
            builder.Services.AddScoped<ITransactionCreditUseCase, TransactionCreditUseCase>();
            builder.Services.AddScoped<ITransactionDebitUseCase, TransactionDeditUseCase>();
            builder.Services.AddScoped<ITransactionHistoryUseCase, TransactionHistoryUseCase>();
            builder.Services.AddScoped<ITransactionTransferUseCase, TransactionTransferUseCase>();
            builder.Services.AddScoped<IGetAllAccountsUseCase, GetAllAccountsUseCase>();
        }
    }
}
