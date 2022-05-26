namespace S1.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {

    }
}

public class DomainNotFoundException : DomainException
{
    public DomainNotFoundException(string message) : base(message)
    {
    }
}

public class DomainValidationException : DomainException
{
    public DomainValidationException(string message) : base(message)
    {
    }
}
