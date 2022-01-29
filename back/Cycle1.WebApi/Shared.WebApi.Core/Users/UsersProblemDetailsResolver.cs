﻿using System.Net;
using System.Resources;
using A3.Library.Mvc.ProblemsDetails;

namespace A3.Shared.WebApi.Core.Users
{
    public class UsersProblemDetailsResolver : ProblemDetailsResolver
    {
        private const string CONTEXT_NAME = "Users";

        protected override ResourceManager ResourceManager => UsersResources.ResourceManager;

        protected override HttpStatusCode GetHttpStatusCode(string rootResourceId)
        {
            if (rootResourceId.Equals("Users_PE_UserSignIn", StringComparison.OrdinalIgnoreCase))
            {
                return HttpStatusCode.Unauthorized;
            }
            return base.GetHttpStatusCode(rootResourceId);
        }

        public UsersProblemDetailsResolver() : base(CONTEXT_NAME)
        {
            this.ResourceManager.IgnoreCase = true;
        }
    }
}
