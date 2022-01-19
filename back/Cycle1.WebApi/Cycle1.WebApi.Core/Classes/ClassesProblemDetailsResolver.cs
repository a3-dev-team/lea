using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/> pour les classes
    /// </summary>
    public class ClassesProblemDetailsResolver : ProblemDetailsResolver
    {
        protected override string ContextName => ClassesResources.NomContexte;

        public ClassesProblemDetailsResolver(int startErrorId, int endErrorId) : base(startErrorId, endErrorId) { }
    }
}
