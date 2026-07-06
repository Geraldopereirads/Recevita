namespace Recevita.Exception.ExeceptionsBase;

public class ErrorOnValidationException : RecevitaExceptions
{
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errorsMessages)
    {
        _errors = errorsMessages;
    }

    public List<string> GetErrorsMessages() => _errors;

}
