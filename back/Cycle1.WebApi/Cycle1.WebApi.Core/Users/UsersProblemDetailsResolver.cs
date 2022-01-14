using A3.Library.Mvc;

namespace A3.Lea.Cycle1.WebApi.Core.Users
{
    public class UsersProblemDetailsResolver : ProblemDetailsResolver
    {
        protected override string ContextName => "Utilisateurs";

        public UsersProblemDetailsResolver(int startErrorId, int endErrorId) : base(startErrorId, endErrorId) { }
    }
}
