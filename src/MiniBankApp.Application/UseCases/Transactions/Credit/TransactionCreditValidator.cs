using FluentValidation;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Exception;

namespace MiniBankApp.Application.UseCases.Transactions.Credit
{
    public class TransactionCreditValidator : AbstractValidator<RequestTransactionCreditJson>
    {
        public TransactionCreditValidator()
        {
            RuleFor(p => p.Value)
                .GreaterThan(0)
                .WithMessage(ResourceErrorMessages.TRANSACTION_VALUE_INVALID);
        }
    }
}
