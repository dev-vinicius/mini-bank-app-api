using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;

namespace MiniBankApp.Application.UseCases.Transactions.Debit.Contracts
{
    public interface ITransactionDebitUseCase
    {
        public ResponseTransactionDebitJson Execute(int accountId, RequestTransactionDebitJson request);
    }
}
