using System.Diagnostics.CodeAnalysis;

namespace A3.Lea.Cycle1.WebApi.Core.Commun
{
    public enum Sexe
    {
        Masculin,
        Feminin
    }

    [Flags]
    [SuppressMessage("Critical Code Smell", "S2346:Flags enumerations zero-value members should be named \"None\"", Justification = "Je code en fr")]
    public enum Sexes
    {
        Aucun = 0,
        Masculin = 1,
        Feminin = 2
    }
}
