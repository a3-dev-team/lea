namespace A3.Shared.WebApi.Core.Users.Passwords
{
    /// <summary>
    /// Hachage et vérification de mot de passe
    /// </summary>
    public interface IPasswordHasher
    {
        // Documentation :
        // https://medium.com/dealeron-dev/storing-passwords-in-net-core-3de29a3da4d2

        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}