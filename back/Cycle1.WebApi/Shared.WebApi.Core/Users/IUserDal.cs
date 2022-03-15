using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Models;

namespace A3.Shared.WebApi.Core.Users
{
    public interface IUserDal
    {
        public Task<Result<User>> GetUserByEMail(string email);

        public Task UpdateUser(User user);
    }
}
