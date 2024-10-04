namespace MiniBankApp.Exception.ExceptionBase
{
    public class ErrorOnTransactionException : MiniBankAppException
    {
        public override string Message { get; }
        public ErrorOnTransactionException(string message)
        {
            Message = message;
        }
    }
}
