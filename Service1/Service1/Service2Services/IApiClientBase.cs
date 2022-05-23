namespace Service1.Service2Services;

public interface IApiClientBase
{
    Task<T> GetWithResponse<T>(string api);
}