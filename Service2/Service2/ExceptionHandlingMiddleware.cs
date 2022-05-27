using S2.Domain.Exceptions;
using System.Net;

namespace Service2
{
	public class ExceptionHandlingMiddleware : IMiddleware
	{
		private readonly ILogger _logger;
		public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
		{
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (DomainNotFoundException e)
			{
				LogTheError(e);
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
				await context.Response.WriteAsync(e.Message);
			}
			catch (Exception e)
			{
				LogTheError(e);
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				await context.Response.WriteAsync("");
			}
		}
		private void LogTheError(Exception e)
		{
			_logger.LogError($"Exception: {e.Message} \r\n InnerException: {e.InnerException} \r\n StackTrace: {e.StackTrace}");

		}
	}
}
