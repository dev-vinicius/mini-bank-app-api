using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

namespace MiniBankApp.Application.Extensions
{
    public static class RegisterDependenciesExtension
    {
        public static void RegisterApplicationServices(this WebApplicationBuilder builder)
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
