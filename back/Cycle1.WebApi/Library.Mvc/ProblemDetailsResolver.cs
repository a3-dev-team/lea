using A3.Library.Results;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;

namespace A3.Library.Mvc
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/>
    /// </summary>
    public abstract class ProblemDetailsResolver : IProblemDetailsResolver
    {
        /// <summary>
        /// Identifiant de l'erreur de début
        /// </summary>
        public int StartErrorId { get; }

        /// <summary>
        /// Identifiant de l'erreur de fin
        /// </summary>
        public int EndErrorId { get; }

        /// <summary>
        /// Est ce que l'instance de resolver courante peut prendre en charge la résolution de l'identifiant d'erreur passé en paramètre en  <see cref="ProblemDetails" ?/>
        /// </summary>
        /// <param name="errorId">Identifiant de l'erreur</param>
        /// <returns>Vrai si la résolution est possible sinon faux</returns>
        private bool IsResolvable(int errorId)
        {
            return errorId >= this.StartErrorId && errorId <= this.EndErrorId;
        }

        protected abstract ProblemDetails ResolveProblemDetails(ErrorResult error);

        /// <summary>
        /// Tente la résolution du contenu du <see cref="Result"/> passé en paramètre en <see cref="ProblemDetails"/>
        /// </summary>
        /// <param name="result"><see cref="Result"/></param>
        /// <param name="problemDetails"><see cref="ProblemDetails"/></param>
        /// <returns>Vrai si la résolution a été possible sinon faux</returns>
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="startErrorId">Identifiant de l'erreur de début</param>
        /// <param name="endErrorId">Identifiant de l'erreur de fin</param>
        protected ProblemDetailsResolver(int startErrorId, int endErrorId)
        {
            Guard.Against.AgainstExpression(i => (i >= startErrorId), endErrorId, "L'identifiant de l'erreur de fin doit être supérieur ou égal à l'identifiant de l'erreur de début");
            this.StartErrorId = startErrorId;
            this.EndErrorId = endErrorId;
        }
    }
}
