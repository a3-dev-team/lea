using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    public interface IElevesService
    {
        List<CarteIdentiteEleve> GetListeCarteIdentiteEleve(int idClasse);
    }
}
