namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class Eleve
    {
        public int Id { get; init; }

        public string? Nom { get; init; }

        public string? Prenom { get; init; }

        public Classe? Classe { get; init; }
        public int? ClasseId { get; init; }

    }
}
