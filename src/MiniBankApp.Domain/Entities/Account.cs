namespace MiniBankApp.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public List<Transaction> Transactions { get; set; } = [];
}
