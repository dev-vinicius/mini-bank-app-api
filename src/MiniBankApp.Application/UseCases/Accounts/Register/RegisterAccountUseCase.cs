using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Accounts;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.Register;

public class RegisterAccountUseCase(
    IAccountRepository repository,
    IUnityOfWork unityOfWork,
    IEventDispatcher eventDispatcher)
    : IRegisterAccountUseCase
{
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

        await repository.SaveAsync(entity);

        await unityOfWork.CommitAsync();

        var eventData = new RegisterAccountEvent(entity.Id, entity.Name);
        await eventDispatcher.DispatchAsync(eventData);

        return new ResponseAccountRegisterJson
        {
            Id = entity.Id
        };
    }

    private static void Validate(RequestAccountRegisterJson request)
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
