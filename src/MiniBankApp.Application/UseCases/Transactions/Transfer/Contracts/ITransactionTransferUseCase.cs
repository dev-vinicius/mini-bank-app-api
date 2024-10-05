using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;

namespace MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts
{
    public interface ITransactionTransferUseCase
    {
        public ResponseTransactionTransferJson Execute(int accountId, RequestTransactionTransferJson request);
    }
}
