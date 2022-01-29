using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Library.Mvc.Test.ProblemsDetails
{

    public class ProblemDetailsResolverTests
    {
        [Fact]
        public void IsResultResovable()
        {
            Result result = new Result();
            result.AddError("Tests_VE_TestValidation.User:Erreur1");
            result.AddError("Tests_VE_TestValidation.User:Erreur2");

            TestProblemDetailsResolver resolver = new TestProblemDetailsResolver();
            Assert.True(resolver.TryResolveProblemDetails(result, out ProblemDetails? problemDetails));
            Assert.True(problemDetails is ValidationProblemDetails);

            result = new Result();
            result.AddError("Tests_PE_TestProblem.ErreurGeneric1");
            result.AddError("Tests_PE_TestProblem.ErreurGeneric2");
            Assert.True(resolver.TryResolveProblemDetails(result, out problemDetails));
            Assert.True(problemDetails != null);
        }
    }
}
