using FluentValidation;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Exception;

namespace MiniBankApp.Application.UseCases.Transactions.Transfer
{
    public class TransactionTransferValidator : AbstractValidator<RequestTransactionTransferJson>
    {
        public TransactionTransferValidator()
        {
            RuleFor(p => p.Value)
                .GreaterThan(0)
                .WithMessage(ResourceErrorMessages.TRANSACTION_VALUE_INVALID);
        }
    }
}
