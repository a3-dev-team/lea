using A3.Library.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ClasseService : ServiceBase<ClasseService>, IClasseService
    {
        public ClasseService(ILogger<ClasseService> logger) : base(logger) { }
    }
}
