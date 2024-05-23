using System.Net;
using UserCarManagementAPI.UserInfra.Exceptions;

namespace UserCarManagementAPI.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public ExceptionsMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            _next = requestDelegate;
            _configuration = configuration;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var apiId = _configuration["ApiSetting:Api_id"];
            ExceptionDTO exResponse = new ExceptionDTO();
            switch (exception)
            {
                case BadRequestException badRequestException:

                    exResponse.Api_id = apiId;
                    exResponse.Response_code = (int)HttpStatusCode.BadRequest;
                    exResponse.Response_message = !string.IsNullOrEmpty(badRequestException.Message) ? badRequestException.Message : "Internal application server error";
                    exResponse.dateTime = DateTime.Now;
                    break;

                case NotFoundException notFoundException:

                    exResponse.Api_id = apiId;
                    exResponse.Response_code = (int)HttpStatusCode.NotFound;
                    exResponse.Response_message = notFoundException.Message;
                    exResponse.dateTime = DateTime.Now;
                    break;

                default:

                    // Default case for other exceptions
                    exResponse.Api_id = apiId;
                    exResponse.Response_code = (int)statusCode;
                    exResponse.Response_message = exception.Message;
                    exResponse.dateTime = DateTime.Now;
                    break;

            }
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(exResponse);
        }
    }
}
