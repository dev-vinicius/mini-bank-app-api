﻿namespace MiniBankApp.Domain.Events.EventData.Accounts
{
    public class RegisterAccountEvent
    {
        public RegisterAccountEvent(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
