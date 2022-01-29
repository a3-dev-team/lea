using A3.Library.Results;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace A3.Library.Mvc.ProblemsDetails
{
    /// <summary>
    /// Classe permettant la création d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/>
    /// </summary>
    public class ProblemDetailsFactory : Hellang.Middleware.ProblemDetails.ProblemDetailsFactory
    {
        private readonly IEnumerable<IProblemDetailsResolver> _resolvers;

        public ProblemDetails? CreateProblemDetails(Result result)
        {
            foreach (IProblemDetailsResolver resolver in this._resolvers)
            {
                if (resolver.TryResolveProblemDetails(result, out ProblemDetails? problemDetails))
                {
                    return problemDetails;
                }
            }
            return null;
        }

        public ProblemDetailsFactory(IEnumerable<IProblemDetailsResolver> resolvers, IOptions<ProblemDetailsOptions> options, ILogger<ProblemDetailsFactory> logger, IHostEnvironment environment) :
            base(options, logger, environment)
        {
            this._resolvers = resolvers;
        }
    }
}
