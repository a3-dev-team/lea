using System.Resources;
using A3.Library.Mvc.ProblemsDetails;

namespace Library.Mvc.Test.ProblemsDetails
{
    internal class TestProblemDetailsResolver : ProblemDetailsResolver
    {
        private const string CONTEXT_NAME = "Tests";

        protected override ResourceManager ResourceManager => TestsResources.ResourceManager;

        public TestProblemDetailsResolver() : base(CONTEXT_NAME)
        {
            this.ResourceManager.IgnoreCase = true;
        }

    }
}
