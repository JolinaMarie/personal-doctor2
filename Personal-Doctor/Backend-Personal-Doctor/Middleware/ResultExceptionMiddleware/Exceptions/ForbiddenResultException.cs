using Microsoft.Extensions.Logging;
using System;

namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware
{
    public class ForbiddenResultException : ApplicationException
    {
        public ForbiddenResultException(string message)
            : base(message)
        {
        }

        public ForbiddenResultException(string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
        }

        public ForbiddenResultException(LogLevel logLevel, string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
            this.LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; private set; } = LogLevel.Warning;
    }
}