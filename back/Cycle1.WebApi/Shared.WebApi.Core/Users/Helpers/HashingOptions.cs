namespace A3.Shared.WebApi.Core.Users.Helpers
{
    /// <summary>
    /// Permet de définir le nombre de cycle de hachage du mot de passe (Niveau de sécurité / Performance)
    /// </summary>
    public sealed class HashingOptions
    {
        // Documentation :
        // https://medium.com/dealeron-dev/storing-passwords-in-net-core-3de29a3da4d2

        public int Iterations { get; set; } = 10000;

    }
}