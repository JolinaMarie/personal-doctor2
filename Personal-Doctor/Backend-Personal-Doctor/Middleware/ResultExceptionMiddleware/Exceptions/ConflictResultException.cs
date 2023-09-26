using Microsoft.Extensions.Logging;
using System;

namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware
{
    public class ConflictResultException : ApplicationException
    {
        public ConflictResultException(string message)
            : base(message)
        {
        }

        public ConflictResultException(string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
        }

        public ConflictResultException(LogLevel logLevel, string message, params object[] args)
            : base(StringHelper.FormatWithAnyPlaceholdername(message, args))
        {
            this.LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; private set; } = LogLevel.Debug;
    }
}