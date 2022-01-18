using A3.Library.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ClassesService : ServiceBase<ClassesService>, IClassesService
    {
        public ClassesService(ILogger<ClassesService> logger) : base(logger) { }
    }
}
