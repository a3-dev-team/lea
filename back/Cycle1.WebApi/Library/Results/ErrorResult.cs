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
        /// <param name="id">Identifiant de l'erreur</param>
        public ErrorResult(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Identifiant de l'erreur
        /// </summary>
        public string Id { get; }
    }
}
