namespace MiniBankApp.Communication.Requests.Transaction
{
    public class RequestTransactionTransferJson
    {
        public int DestinationAccountId { get; set; }
        public decimal Value { get; set; }
    }
}
