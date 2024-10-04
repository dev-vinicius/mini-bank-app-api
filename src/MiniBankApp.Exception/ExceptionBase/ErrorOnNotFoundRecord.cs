namespace MiniBankApp.Exception.ExceptionBase
{
    public class ErrorOnNotFoundRecord : MiniBankAppException
    {
        public override string Message { get; }
        public ErrorOnNotFoundRecord(string message) 
        {
            Message = message;
        }
    }
}
