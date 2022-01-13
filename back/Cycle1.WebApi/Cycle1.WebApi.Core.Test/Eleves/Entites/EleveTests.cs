using System.Net.Mail;
using Xunit;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using A3.Lea.Cycle1.WebApi.Core.Commun;

public class CarteIdentiteEleveTests
{
    [Fact]
    public void EstGarcon_SexeMasculin_ReturnTrue()
    {
        CarteIdentiteEleve carteIdentiteEleve = new CarteIdentiteEleve(1,"Nom","Prenom",Sexe.Masculin,Niveau.PetiteSection,null);

        Assert.True(carteIdentiteEleve.EstUnGarcon(), $"{carteIdentiteEleve.Sexe} devrait être un garçon");

    }
}