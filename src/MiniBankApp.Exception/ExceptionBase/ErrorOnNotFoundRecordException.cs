namespace MiniBankApp.Exception.ExceptionBase
{
    public class ErrorOnNotFoundRecordException : MiniBankAppException
    {
        public override string Message { get; }
        public ErrorOnNotFoundRecordException(string message) 
        {
            Message = message;
        }
    }
}
