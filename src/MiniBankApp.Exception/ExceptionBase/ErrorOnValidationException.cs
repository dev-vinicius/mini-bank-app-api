namespace MiniBankApp.Exception.ExceptionBase
{
    public class ErrorOnValidationException : MiniBankAppException
    {
        public List<string> Errors { get; set; }
        public ErrorOnValidationException(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
