using MiniBankApp.Domain.Enums;

namespace MiniBankApp.Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public int OriginAccountId { get; set; }
    public decimal Value { get; set; }
    public OperationType OperationType { get; set; }
    public int DestinationAccountId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
