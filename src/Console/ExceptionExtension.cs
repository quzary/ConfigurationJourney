using System;
using System.Collections;
using System.Text;
using Lodgify.Extensions.Enumerations;

namespace Console
{
    public static class ExceptionExtension
    {
        public static string GetDetails(this Exception exception, StringBuilder sb = null)
        {
            if (exception == null)
            {
                return sb?.ToString() ?? string.Empty;
            }
            if (sb == null)
            {
                sb = new StringBuilder();
                sb.AppendLine();
            }
            sb.AppendLine($"Type: {exception.GetType()}");
            sb.AppendLine($"Message: {exception.Message}");
            sb.AppendLine($"Source: {exception.Source}");

            if (!exception.Data.IsNullOrEmpty())
            {
                sb.AppendLine("Data:");
                foreach (DictionaryEntry entry in exception.Data)
                {
                    sb.AppendLine($"{entry.Key}={entry.Value}");
                }
            }
            sb.AppendLine($"StackTrace: {exception.StackTrace}");
            sb.AppendLine((exception.InnerException != null) ? "********* Inner exception: *********" : "********* No inner exception: *********");

            exception.InnerException.GetDetails(sb);
            return sb.ToString();
        }
    }
}