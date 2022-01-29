using System.Net;
using System.Resources;
using A3.Library.Mvc.Extensions;
using A3.Library.Mvc.ProblemsDetails;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Library.Mvc
{
    /// <summary>
    /// ControllerBase
    /// </summary>
    public abstract class ControllerBase<TSelf> : ControllerBase
        where TSelf : ControllerBase<TSelf>
    {
        protected ILogger<TSelf> Logger { get; }

        protected virtual ResourceManager? ResourceManager => null;

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
            this.Logger.LogResult(result, this.ResourceManager);
            ProblemDetails? problemDetails = this.ProblemDetailsFactory.CreateProblemDetails(result);
            if (problemDetails != null)
            {
                return this.StatusCode(problemDetails.Status ?? (int)HttpStatusCode.BadRequest, problemDetails);
            }

            throw new Hellang.Middleware.ProblemDetails.ProblemDetailsException((int)HttpStatusCode.InternalServerError, "Erreur inconnue");
        }

        private IActionResult ResultAsActionResult<T>(Result<T> result)
        {
            if (result.IsValid)
            {
                return this.Ok(result.Value);
            }
            return this.Problem(result);
        }

        public IActionResult GetActionResult<T>(Result<T> result)
        {
            return this.ResultAsActionResult(result);
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
            return this.ResultAsActionResult(result);
        }

        public IActionResult DeleteActionResult<T>(Result<T> result)
        {
            return this.ResultAsActionResult(result);
        }

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
        where TSelf : ControllerBase<TSelf>
        where TService : class
    {
        protected TService Service { get; }

        protected ControllerBase(TService service, ILogger<TSelf> logger) : base(logger)
        {
            this.Service = service;
        }
    }
}
