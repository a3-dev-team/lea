using A3.Lea.Cycle1.WebApi.Core.Commun;
using Xunit;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class IdentiteEleveTests
    {
        [Fact]
        public void EstGarcon_SexeMasculin_ReturnTrue()
        {
            IdentiteEleve identiteEleve = new IdentiteEleve(1, "Nom", "Prenom", Sexe.Masculin, Niveau.PetiteSection, null);
            Assert.True(identiteEleve.EstUnGarcon(), $"{identiteEleve.Sexe} devrait être un garçon");
        }
    }
}