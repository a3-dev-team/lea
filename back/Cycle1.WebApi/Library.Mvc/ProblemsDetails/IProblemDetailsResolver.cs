using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Library.Mvc.ProblemsDetails
{
    /// <summary>
    /// Interface permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/>
    /// </summary>
    public interface IProblemDetailsResolver
    {
        string ContextName { get; }

        bool TryResolveProblemDetails(Result result, out ProblemDetails? problemDetails);
    }
}
