using MiniBankApp.Communication.Responses.Transaction;

namespace MiniBankApp.Communication.Events.Transactions
{
    public class TransactionEvent
    {
        public TransactionEvent(int id, 
            int originAccountId, 
            decimal value, 
            OperationType operationType, 
            int? destinationAccountId, 
            DateTime transactionDate)
        {
            Id = id;
            OriginAccountId = originAccountId;
            Value = value;
            OperationType = operationType;
            DestinationAccountId = destinationAccountId;
            TransactionDate = transactionDate;
        }
        public int Id { get; set; }
        public int OriginAccountId { get; set; }
        public decimal Value { get; set; }
        public OperationType OperationType { get; set; }
        public int? DestinationAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
