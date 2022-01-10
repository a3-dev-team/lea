using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;

namespace A3.Library.Mvc
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/>
    /// </summary>
    public abstract class ProblemDetailsResolver : IProblemDetailsResolver
    {
        public int StartErrorId { get; }

        public int EndErrorId { get; }

        private bool IsResolvable(int errorId)
        {
            return errorId >= this.StartErrorId && errorId <= this.EndErrorId;
        }

        protected abstract ProblemDetails ResolveProblemDetails(ErrorResult error);

        public bool TryResolveProblemDetails(Result result, out ProblemDetails? problemDetails)
        {
            if (!result.IsValid)
            {
                ErrorResult? error = result.GetErrors().FirstOrDefault();
                if (error != null && this.IsResolvable(error.ErrorId))
                {
                    problemDetails = this.ResolveProblemDetails(error);
                    return true;
                }
            }
            problemDetails = null;
            return false;
        }

        protected ProblemDetailsResolver(int startErrorId, int endErrorId)
        {
            this.StartErrorId = startErrorId;
            this.EndErrorId = endErrorId;
        }
    }
}
