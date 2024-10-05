using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.Register;

public class RegisterAccountUseCase : IRegisterAccountUseCase
{
    private readonly IRegisterAccountRepository _repository;
    public RegisterAccountUseCase(IRegisterAccountRepository repository)
    {
        _repository = repository;
    }

    public ResponseAccountRegisterJson Execute(RequestAccountRegisterJson request)
    {
        Validate(request);

        var entity = new Account
        {
            Name = request.Name!,
            Balance = request.Balance,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
        };

        _repository.Save(entity);

        return new ResponseAccountRegisterJson
        {
            Id = entity.Id
        };
    }

    private void Validate(RequestAccountRegisterJson request)
    {
        var validator = new RegisterAccountValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
