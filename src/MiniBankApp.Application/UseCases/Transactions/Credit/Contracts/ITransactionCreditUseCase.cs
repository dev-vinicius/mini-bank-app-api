using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;

namespace MiniBankApp.Application.UseCases.Transactions.Credit.Contracts
{
    public interface ITransactionCreditUseCase
    {
        public Task<ResponseTransactionCreditJson> Execute(int accountId, RequestTransactionCreditJson request);
    }
}
