namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class Eleve
    {
        public int Id { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public Classe? Classe { get; set; }
        public int? ClasseId { get; set; }

    }
}
