namespace MiniBankApp.Communication.Responses.Transaction
{
    public class ResponseTransactionHistoryJson
    {
        public List<TransactionHistoryItem> Transactions { get; set; } = [];
    }

    public class TransactionHistoryItem
    {
        public decimal Value { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime Date { get; set; }
        public bool TransferRecieved { get; set; }
    }

    public enum OperationType
    {
        Credit = 0,
        Debit = 1,
        Transfer = 2
    }

}
