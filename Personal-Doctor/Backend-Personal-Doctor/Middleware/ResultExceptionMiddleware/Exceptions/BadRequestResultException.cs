using Microsoft.Extensions.Logging;
using System;

namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware
{
    public class BadRequestResultException : ApplicationException
    {
        public BadRequestResultException(string message)
            : base(message)
        {
        }

        public BadRequestResultException(string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
        }

        public BadRequestResultException(LogLevel logLevel, string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
            this.LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; private set; } = LogLevel.Debug;
    }
}