using System;

namespace MiniBankApp.Communication.Requests.Account;

public class RequestAccountRegisterJson
{
    public string? Name { get; set; }
    public decimal Balance { get; set; }
}
