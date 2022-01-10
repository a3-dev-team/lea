namespace A3.Librairie.Results
{
    public static class ResultExtension
    {
        public static bool IsValidAndValued<T>(this Result<T> result)
        {
            return result.IsValid && IsValued(result);
        }

        public static bool IsValued<T>(this Result<T> resultat)
        {
            return resultat.Value != null;
        }
    }
}
