using System.Resources;
using A3.Library.Mvc.ProblemsDetails;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Lea.Cycle1.WebApi.Core.Objectifs
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/> pour les élèves
    /// </summary>
    public class ObjectifProblemDetailsResolver : ProblemDetailsResolver
    {
        private const string CONTEXT_NAME = "eleves";

        protected override ResourceManager ResourceManager => ObjectifResources.ResourceManager;

        public ObjectifProblemDetailsResolver() : base(CONTEXT_NAME) { }
    }
}
