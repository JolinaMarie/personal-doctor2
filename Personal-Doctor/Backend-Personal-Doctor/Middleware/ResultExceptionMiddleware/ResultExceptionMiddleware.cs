
using Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware.Exceptions;

namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware
{
    public class ResultExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ResultExceptionMiddleware> logger;

        public ResultExceptionMiddleware(
            RequestDelegate next,
            ILogger<ResultExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestResultException e)
            {
                logger.Log(e.LogLevel, e.Message);
                await this.WriteResponse(context, 400, e.Message);
            }
            catch (ConflictResultException e)
            {
                logger.Log(e.LogLevel, e.Message);
                await this.WriteResponse(context, 409, e.Message);
            }
            catch (ForbiddenResultException e)
            {
                logger.Log(e.LogLevel, e.Message);
                await this.WriteResponse(context, 403, e.Message);
            }
            catch (UnauthorizedResultException e)
            {
                logger.Log(e.LogLevel, e.Message);
                await this.WriteResponse(context, 401, e.Message);
            }
            catch (NotFoundResultException e)
            {
                logger.Log(e.LogLevel, e.Message);
                await this.WriteResponse(context, 404, e.Message);
            }
        }

        private async Task WriteResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(message);
        }
    }
}