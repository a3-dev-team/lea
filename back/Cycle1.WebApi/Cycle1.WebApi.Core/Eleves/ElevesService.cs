namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    public class ElevesService : IElevesService
    {
        private readonly IElevesDal _elevesDal;

        public ElevesService(IElevesDal elevesDal)
        {
            this._elevesDal = elevesDal;
        }
    }
}
