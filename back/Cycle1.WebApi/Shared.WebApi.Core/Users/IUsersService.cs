﻿using A3.Library.Mvc.Jwt;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Models;

namespace A3.Shared.WebApi.Core.Users
{
    public interface IUsersService
    {
        Result<AuthenticatedUser?> GetAuthenticatedUser(SignInInformation signInInformation, JwtSettings jwtSettings);
    }
}
