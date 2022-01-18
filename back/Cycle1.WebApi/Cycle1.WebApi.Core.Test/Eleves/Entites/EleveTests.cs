using Xunit;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using A3.Lea.Cycle1.WebApi.Core.Commun;

public class CarteIdentiteEleveTests
{
    [Fact]
    public void EstGarcon_SexeMasculin_ReturnTrue()
    {
        IdentiteEleve identiteEleve = new IdentiteEleve(1, "Nom", "Prenom", Sexe.Masculin, Niveau.PetiteSection, null);
        Assert.True(identiteEleve.EstUnGarcon(), $"{identiteEleve.Sexe} devrait être un garçon");
    }
}