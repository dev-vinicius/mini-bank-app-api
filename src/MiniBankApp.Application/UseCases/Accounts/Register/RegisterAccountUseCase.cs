using System;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;

namespace MiniBankApp.Application.UseCases.Accounts.Register;

public class RegisterAccountUseCase
{
    public ResponseAccountRegisterJson Execute(RequestAccountRegisterJson request)
    {
        return new ResponseAccountRegisterJson();
    }
}
