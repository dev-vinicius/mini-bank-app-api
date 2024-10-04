﻿using FluentValidation;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Exception;

namespace MiniBankApp.Application.UseCases.Accounts.Register
{
    public class RegisterAccountValidator : AbstractValidator<RequestAccountRegisterJson>
    {
        public RegisterAccountValidator()
        {
            RuleFor(req => req.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage(ResourceErrorMessages.ACCOUNT_NAME_INVALID);

            RuleFor(req => req.Balance)
                .GreaterThan(0)
                .WithMessage(ResourceErrorMessages.ACCOUNT_BALANCE_INVALID);
        }
    }
}