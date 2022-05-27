namespace S1.Application.Services.Service2Services.Exceptions
{
    public class Service2Exception : Exception
    {
        public Service2Exception(string message) : base(message)
        {

        }
    }

    public class Service2NotFoundException : Service2Exception
    {
        public Service2NotFoundException(string message) : base(message)
        {
        }
    }

}
