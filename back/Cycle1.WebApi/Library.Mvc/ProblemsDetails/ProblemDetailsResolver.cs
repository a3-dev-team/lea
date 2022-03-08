using System.Net;
using System.Resources;
using A3.Library.Results;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;

namespace A3.Library.Mvc.ProblemsDetails
{
    /// <summary>
    /// Classe permettant la déduction d'un <see cref="ProblemDetails"/> à partir d'un <see cref="Result"/>
    /// </summary>
    public abstract class ProblemDetailsResolver : IProblemDetailsResolver
    {
        private const string ERROR_TITLE = "Title";
        private const string ERROR_DETAIL = "Detail";
        private const string ERROR_PROPERTY = "Property";
        private const string DEFAULT_CONTEXT_LABEL = "DefaultContextLabel";
        private const string VALIDATION_ERROR_FLAG = "VE";

        /// <summary>
        /// Nom du contexte du <see cref="ProblemDetailsResolver"/>
        /// </summary>
        public string ContextName { get; }

        /// <summary>
        /// ResourceManager permettant l'accés à la ressource
        /// </summary>
        protected abstract ResourceManager ResourceManager { get; }

        private static string GetRootResourceId(string errorId)
        {
            return errorId.Split('.')[0]; //Regex ?
        }

        private static string GetDetailResourceId(string rootResourceId)
        {
            return $"{rootResourceId}.{ERROR_DETAIL}";
        }

        private static string GetPropertyResourceId(string errorId)
        {
            return $"{errorId.Split(':')[0]}.{ERROR_PROPERTY}";
        }

        private static string GetTitleResourceId(string rootResourceId)
        {
            return $"{rootResourceId}.{ERROR_TITLE}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorId"></param>
        /// <returns></returns>
        private bool IsValidationError(string errorId)
        {
            return errorId.StartsWith($"{this.ContextName}_{VALIDATION_ERROR_FLAG}", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Est ce que l'instance de resolver courante peut prendre en charge la résolution de l'identifiant d'erreur passé en paramètre en  <see cref="ProblemDetails" ?/>
        /// </summary>
        /// <param name="errorId">Identifiant de l'erreur</param>
        /// <returns>Vrai si la résolution est possible sinon faux</returns>
        private bool IsResolvable(string errorId)
        {
            return errorId.StartsWith(this.ContextName, StringComparison.OrdinalIgnoreCase);
        }

        private string GetDefaultContextLabelResourceId()
        {
            return $"{this.ContextName}.{DEFAULT_CONTEXT_LABEL}";
        }

        private string GetErrorTitle(string rootResourceId)
        {
            return this.ResourceManager.GetString(GetTitleResourceId(rootResourceId)) ?? // Titre spécifique pour l'erreur
            this.ResourceManager.GetString(this.GetDefaultContextLabelResourceId()) ?? // Sinon titre par défaut
            rootResourceId; // Sinon identifiant de l'erreur
        }

        private string GetErrorProperty(string errorId)
        {
            string propertyResourceId = GetPropertyResourceId(errorId);
            return this.ResourceManager.GetString(propertyResourceId) ?? propertyResourceId;
        }

        private string GetErrorDetail(string rootResourceId)
        {
            string detailResourceId = GetDetailResourceId(rootResourceId);
            return this.ResourceManager.GetString(detailResourceId) ?? detailResourceId;
        }

        /// <summary>
        /// Transforme un <see cref="Result"/> en <see cref="ValidationProblemDetails"/>
        /// </summary>
        /// <param name="result"><see cref="Result"/></param>
        /// <returns><see cref="ValidationProblemDetails"/></returns>
        private ValidationProblemDetails ToValidationProblemDetails(Result result, string rootResourceId)
        {
            ValidationProblemDetails validationProblemDetails = new ValidationProblemDetails()
            {
                Title = this.GetErrorTitle(rootResourceId),
                Detail = this.GetErrorDetail(rootResourceId),
                Status = (int)this.GetHttpStatusCode(rootResourceId)
            };
            foreach (string errorId in result.GetErrors().Select(error => error.Id))
            {
                string errorProperty = this.GetErrorProperty(errorId);
                string errorResource = this.ResourceManager.GetString(errorId) ?? errorId;

                if (validationProblemDetails.Errors.TryGetValue(errorProperty, out string[]? value))
                {
                    validationProblemDetails.Errors[errorProperty] = value.Append(errorResource).ToArray();
                }
                else
                {
                    validationProblemDetails.Errors.Add(errorProperty, new string[] { errorResource });
                }
            }
            return validationProblemDetails;
        }

        /// <summary>
        /// Transforme un <see cref="Result"/> en <see cref="ProblemDetails"/>
        /// </summary>
        /// <param name="result"><see cref="Result"/></param>
        /// <returns><see cref="ProblemDetails"/></returns>
        private ProblemDetails ToProblemDetails(Result result, string rootResourceId)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Title = this.GetErrorTitle(rootResourceId),
                Detail = string.Join(Environment.NewLine, result.GetErrors().Select(error => this.ResourceManager.GetString(error.Id) ?? error.Id)),
                Status = (int)this.GetHttpStatusCode(rootResourceId)
            };

            return problemDetails;
        }

        protected virtual HttpStatusCode GetHttpStatusCode(string rootResourceId)
        {
            return HttpStatusCode.BadRequest;
        }

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
                if (error != null && this.IsResolvable(error.Id))
                {
                    string rootResourceId = GetRootResourceId(error.Id);

                    problemDetails = this.IsValidationError(error.Id) ?
                        this.ToValidationProblemDetails(result, rootResourceId) :
                        this.ToProblemDetails(result, rootResourceId);

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
        protected ProblemDetailsResolver(string contextName)
        {
            Guard.Against.NullOrEmpty(contextName, nameof(contextName));
            this.ContextName = contextName;
            this.ResourceManager.IgnoreCase = true;
        }
    }
}
