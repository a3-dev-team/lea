using System.Net;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/> pour les élèves
    /// </summary>
    public class ElevesProblemDetailsResolver : ProblemDetailsResolver
    {
        protected override ProblemDetails ResolveProblemDetails(ErrorResult error)
        {
            return new ProblemDetails()
            {
                Status = (int)HttpStatusCode.BadRequest,
                Detail = error.Message,
                Title = "Obtention des élèves d'une classe"
            };
        }

        public ElevesProblemDetailsResolver(int startErrorId, int endErrorId) : base(startErrorId, endErrorId) { }
    }
}
