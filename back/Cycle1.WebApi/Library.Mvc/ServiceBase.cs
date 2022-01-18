using Microsoft.Extensions.Logging;

namespace A3.Library.Mvc
{
    /// <summary>
    /// ServiceBase
    /// </summary>
    /// <typeparam name="TSelf">ServiceBase</typeparam>
    public abstract class ServiceBase<TSelf>
    {
        protected ILogger<TSelf> Logger { get; }

        protected ServiceBase(ILogger<TSelf> logger)
        {
            this.Logger = logger;
        }
    }
}
