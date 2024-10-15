using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Accounts;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.Register;

public class RegisterAccountUseCase : IRegisterAccountUseCase
{
    private readonly IRegisterAccountRepository _repository;
    private readonly IEventDispatcher _eventDispatcher;
    public RegisterAccountUseCase(IRegisterAccountRepository repository,
        IEventDispatcher eventDispatcher)
    {
        _repository = repository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task<ResponseAccountRegisterJson> Execute(RequestAccountRegisterJson request)
    {
        Validate(request);

        var entity = new Account
        {
            Name = request.Name!,
            Balance = decimal.Zero,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
        };

        await _repository.Save(entity);

        var eventData = new RegisterAccountEvent(entity.Id, entity.Name);
        await _eventDispatcher.DispatchAsync(eventData);

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
