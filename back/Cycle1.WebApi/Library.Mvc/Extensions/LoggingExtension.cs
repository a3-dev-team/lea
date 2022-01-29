using System.Resources;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Library.Mvc.Extensions
{
    /// <summary>
    /// Classe d'extension pour le logging ajoutant la gestion du <see cref="Result"/>
    /// </summary>
    public static class LoggingExtension
    {
        public static void LogResult(this ILogger logger, Result result, ResourceManager? resourceManager)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                foreach (string errorId in result.GetErrors().Select(error => error.Id))
                {
                    logger.LogError(resourceManager != null ? resourceManager.GetString(errorId) : errorId);
                }
            }
        }
    }
}
