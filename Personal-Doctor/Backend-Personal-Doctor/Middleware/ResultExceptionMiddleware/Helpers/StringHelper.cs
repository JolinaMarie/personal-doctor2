using System;
using System.Text.RegularExpressions;

namespace Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware
{
    internal static class StringHelper
    {
        public static string FormatWithAnyPlaceholdername(string format, params object[] args)
        {
            Regex r = new Regex(@"\{([A-Za-z0-9_]+)\}");
            MatchCollection matches = r.Matches(format);

            for (int i = 0; i < matches.Count; i++)
            {
                try
                {
                    string propertyName = matches[i].Groups[1].Value;
                    format = format.Replace(matches[i].Value, args[i].ToString());
                }
                catch
                {
                    throw new FormatException("The string format is not valid");
                }
            }

            return format;
        }
    }
}