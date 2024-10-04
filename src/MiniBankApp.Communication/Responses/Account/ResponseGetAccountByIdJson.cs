namespace MiniBankApp.Communication.Responses.Account
{
    public class ResponseGetAccountByIdJson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
    }
}
