using A3.Library.Mvc;

namespace A3.Shared.WebApi.Core.Users
{
    public class UsersProblemDetailsResolver : ProblemDetailsResolver
    {
        protected override string ContextName => UsersResources.ContextName;

        public UsersProblemDetailsResolver(int startErrorId, int endErrorId) : base(startErrorId, endErrorId) { }
    }
}
