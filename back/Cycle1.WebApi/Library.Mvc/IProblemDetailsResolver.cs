using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Library.Mvc
{
    /// <summary>
    /// Interface permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/>
    /// </summary>
    public interface IProblemDetailsResolver
    {
        bool TryResolveProblemDetails(Result result, out ProblemDetails? problemDetails);
    }
}
