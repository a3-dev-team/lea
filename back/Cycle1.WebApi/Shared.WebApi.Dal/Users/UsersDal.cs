using A3.Library.Mvc;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace A3.Shared.WebApi.Dal.Users
{
    public class UsersDal : DalBase<User>, IUsersDal
    {
        public UsersDal(SharedDatabaseContext sharedDatabaseContext)
             : base(sharedDatabaseContext)
        { }

        async Task<Result<User>> IUsersDal.GetByEMail(string email)
        {
            return new Result<User>()
            {
                Value = await this.FindByCondition(e => e.Email.Equals(email)).SingleOrDefaultAsync()
            };
        }

        Task IUsersDal.Update(User user)
        {
            return this.UpdateAndSaveAsync(user);
        }
    }
}
