namespace S1.Application.Services.Service3.Services.Exceptions
{
    public class Service3Exception : Exception
    {
        public Service3Exception(string message) : base(message)
        {

        }
    }

    public class Service3NotFoundException : Service3Exception
    {
        public Service3NotFoundException(string message) : base(message)
        {
        }
    }
}
