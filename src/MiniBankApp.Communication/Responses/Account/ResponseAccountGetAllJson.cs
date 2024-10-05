namespace MiniBankApp.Communication.Responses.Account
{
    public class ResponseAccountGetAllJson
    {
        public List<ResponseAccountGetAllItem> Accounts { get; set; } = [];
    }

    public class ResponseAccountGetAllItem 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
