using FluentValidation;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Exception;

namespace MiniBankApp.Application.UseCases.Transactions.Debit
{
    public class TransactionDebitValidator : AbstractValidator<RequestTransactionDebitJson>
    {
        public TransactionDebitValidator()
        {
            RuleFor(p => p.Value)
                .GreaterThan(0)
                .WithMessage(ResourceErrorMessages.TRANSACTION_VALUE_INVALID);
        }
    }
}
