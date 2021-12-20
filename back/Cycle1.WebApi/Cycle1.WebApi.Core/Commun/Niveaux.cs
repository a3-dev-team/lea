namespace A3.Lea.Cycle1.WebApi.Core.Commun
{
    public enum Niveau
    {
        PetiteSection,
        MoyenneSection,
        GrandeSection
    }

    [Flags]
    public enum Niveaux
    {
        Aucun = 0,
        PetiteSection = 1,
        MoyenneSection = 2,
        GrandeSection = 4
    }
}
