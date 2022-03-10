namespace A3.Lea.Cycle1.WebApi.Core.Commun.Modeles
{
    public class Adresse
    {
        public int Id { get; }

        public string? Voie { get; set; }

        public string? Complement { get; set; }

        public string? BoitePostale { get; set; }

        public string? CodePostal { get; set; }

        public string? Commune { get; set; }

        public Adresse(int id)
        {
            this.Id = id;
        }
    }
}
