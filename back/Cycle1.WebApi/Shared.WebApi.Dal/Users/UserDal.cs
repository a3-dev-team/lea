using A3.Library.Mvc;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace A3.Shared.WebApi.Dal.Users
{
    public class UserDal : EntityFrameworkDalBase<User>, IUserDal
    {
        public UserDal(SharedDbContext sharedDatabaseContext)
             : base(sharedDatabaseContext)
        { }

        public async Task<Result<User>> GetUserByEMail(string email)
        {
            return new Result<User>()
            {
                Value = await this.FindByCondition(e => e.Email.Equals(email)).SingleOrDefaultAsync()
            };
        }

        public async Task UpdateUser(User user)
        {
            await this.UpdateAndSaveAsync(user);
        }
    }
}
