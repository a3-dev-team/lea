using System.Net;
using A3.Library.Results;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Library.Mvc
{
    /// <summary>
    /// ControllerBase
    /// </summary>
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public new ProblemDetailsFactory ProblemDetailsFactory
        {
            get
            {
                return (ProblemDetailsFactory)base.ProblemDetailsFactory;
            }
            set
            {
                base.ProblemDetailsFactory = value;
            }
        }

        private IActionResult Problem(Result result)
        {
            ProblemDetails? problemDetails = this.ProblemDetailsFactory.CreateProblemDetails(result);
            if (problemDetails != null)
            {
                return this.StatusCode(problemDetails.Status ?? (int)HttpStatusCode.BadRequest, problemDetails);
            }

            throw new ProblemDetailsException((int)HttpStatusCode.BadRequest, "Erreur inconnue");
        }

        private IActionResult Ok<T>(Result<T> result)
        {
            if (result.IsValid)
            {
                return this.Ok(result.Value);
            }
            return this.Problem(result);
        }

        public IActionResult GetActionResult<T>(Result<T> result)
        {
            return this.Ok(result);
        }

        public IActionResult PostActionResult<T>(Result<T> result, string? routeName = null)
        {
            if (result.IsValid)
            {
                return routeName != null ? this.CreatedAtRoute(routeName, result.Value) : this.StatusCode((int)HttpStatusCode.Created);
            }
            return this.Problem(result);
        }

        public IActionResult PutActionResult<T>(Result<T> result)
        {
            return this.Ok(result);
        }

        public IActionResult DeleteActionResult<T>(Result<T> result)
        {
            return this.Ok(result);
        }
    }

    /// <summary>
    /// ControllerBase
    /// </summary>
    /// <typeparam name="TSelf">ControllerBase</typeparam>
    public abstract class ControllerBase<TSelf> : ControllerBase
        where TSelf : ControllerBase
    {
        protected ILogger<TSelf> Logger { get; }

        protected ControllerBase(ILogger<TSelf> logger)
        {
            this.Logger = logger;
        }
    }

    /// <summary>
    /// ControllerBase
    /// </summary>
    /// <typeparam name="TSelf">ControllerBase</typeparam>
    /// <typeparam name="TService">Type de service lié au controller</typeparam>
    public abstract class ControllerBase<TSelf, TService> : ControllerBase<TSelf>
        where TSelf : ControllerBase
        where TService : class
    {
        protected TService Service { get; }

        protected ControllerBase(TService service, ILogger<TSelf> logger) : base(logger)
        {
            this.Service = service;
        }
    }
}
