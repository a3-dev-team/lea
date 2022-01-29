using System.Resources;
using A3.Library.Mvc.ProblemsDetails;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/> pour les classes
    /// </summary>
    public class ClassesProblemDetailsResolver : ProblemDetailsResolver
    {
        private const string CONTEXT_NAME = "classes";

        protected override ResourceManager ResourceManager => ClassesResources.ResourceManager;

        public ClassesProblemDetailsResolver() : base(CONTEXT_NAME) { }

    }
}
