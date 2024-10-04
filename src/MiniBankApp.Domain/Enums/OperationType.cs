using System;
using System.ComponentModel.DataAnnotations;

namespace MiniBankApp.Domain.Enums;

public enum OperationType
{
    Credit = 0,
    Debit = 1,
    Transfer = 3
}