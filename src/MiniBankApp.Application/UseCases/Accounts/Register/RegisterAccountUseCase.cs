using MiniBankApp.Application.Events;
using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Communication.Events.Accounts;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.Register;

public class RegisterAccountUseCase : IRegisterAccountUseCase
{
    private readonly IRegisterAccountRepository _repository;
    private readonly IEventPublisher _eventPublisher;
    public RegisterAccountUseCase(IRegisterAccountRepository repository, 
        IEventPublisher eventPublisher)
    {
        _repository = repository;
        _eventPublisher = eventPublisher;
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

        _repository.Save(entity);

        var eventData = new RegisterAccountEvent(entity.Id, entity.Name);
        await _eventPublisher.PublishAsync(eventData);

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
