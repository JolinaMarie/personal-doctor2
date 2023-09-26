namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware.Exceptions
{
    public class UnauthorizedResultException : ApplicationException
    {

        public UnauthorizedResultException(string message)
            : base(message)
        {
        }

        public UnauthorizedResultException(string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
        }

        public UnauthorizedResultException(LogLevel logLevel, string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
            this.LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; private set; } = LogLevel.Warning;
    }
}


