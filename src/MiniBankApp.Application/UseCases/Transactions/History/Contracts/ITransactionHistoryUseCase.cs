using MiniBankApp.Communication.Responses.Transaction;

namespace MiniBankApp.Application.UseCases.Transactions.History.Contracts
{
    public interface ITransactionHistoryUseCase
    {
        public Task<ResponseTransactionHistoryJson> Execute(int accountId);
    }
}
