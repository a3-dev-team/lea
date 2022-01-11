using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    public interface IElevesDal
    {
        List<CarteIdentiteEleve> GetListeCarteIdentiteEleve(int idClasse);

        List<Eleve> GetListeEleve(int idClasse);

    }
}
