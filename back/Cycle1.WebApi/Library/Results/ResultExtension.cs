namespace A3.Library.Results
{
    /// <summary>
    /// Classe d'extension pour le <see cref="Result"/>
    /// </summary>
    public static class ResultExtension
    {
        /// <summary>
        /// Le <see cref="Result{T}"/> est-il valide et valorisé ?
        /// </summary>
        /// <typeparam name="T">Le type de la valeur</typeparam>
        /// <param name="result"><see cref="Result{T}"/></param>
        /// <returns>Vrai si valide et valorisé sinon faux</returns>
        public static bool IsValidAndValued<T>(this Result<T> result)
        {
            return result.IsValid && IsValued(result);
        }

        /// <summary>
        /// Le <see cref="Result{T}"/> est-il valorisé ?
        /// </summary>
        /// <typeparam name="T">Le type de la valeur</typeparam>
        /// <param name="resultat"><see cref="Result{T}"/></param>
        /// <returns>Vrai si valorisé sinon faux</returns>
        public static bool IsValued<T>(this Result<T> resultat)
        {
            return resultat.Value != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string GetErrorsAsString(this Result result)
        {
            return string.Join(Environment.NewLine, result.GetErrors().Select(error => error.Message));
        }
    }
}
