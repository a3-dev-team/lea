using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Models;

namespace A3.Shared.WebApi.Core.Users
{
    public interface IUsersDal
    {
        public Task<Result<User>> GetByEMail(string email);
        public Task Update(User user);
    }
}
