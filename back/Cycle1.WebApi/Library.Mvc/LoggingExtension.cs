using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Library
{
    /// <summary>
    /// Classe d'extension pour le logging ajoutant la gestion du <see cref="Result"/>
    /// </summary>
    public static class LoggingExtension
    {
        public static void Log(this ILogger logger, LogLevel logLevel, Result result)
        {
            foreach (ErrorResult error in result.GetErrors())
            {
                logger.Log(logLevel, "Id : {0} - Message : {1}", error.ErrorId, error.Message);
            }
        }

        public static void Log<T>(this ILogger logger, LogLevel logLevel, Result<T> result)
        {
            logger.Log(logLevel, result.Value != null ? result.Value.ToString() : "Value result is null");
            logger.Log(logLevel, result);
        }
    }
}
