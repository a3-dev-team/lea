namespace A3.Library.Results
{
    /// <summary>
    /// Classe d'erreur contenu dans un <see cref="Result"/>
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="errorId">Identifiant de l'erreur</param>
        /// <param name="message">Message de l'erreur</param>
        public ErrorResult(int errorId, string message)
        {
            this.ErrorId = errorId;
            this.Message = message;
        }

        /// <summary>
        /// Identifiant de l'erreur
        /// </summary>
        public int ErrorId { get; }

        /// <summary>
        /// Message de l'erreur
        /// </summary>
        public string Message { get; }
    }
}
