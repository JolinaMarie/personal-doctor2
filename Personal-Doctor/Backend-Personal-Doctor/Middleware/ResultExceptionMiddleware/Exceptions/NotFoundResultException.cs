
namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware
{
    public class NotFoundResultException : ApplicationException
    {
        public NotFoundResultException(string message)
            : base(message)
        {
        }

        public NotFoundResultException(string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
        }

        public NotFoundResultException(LogLevel logLevel, string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
            this.LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; private set; } = LogLevel.Debug;
    }
}