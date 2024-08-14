

using Soft.Bussiness.Core.Data;
using Soft.Bussiness.Models.Books;
using Soft.Bussiness.Models.Users;

namespace Soft.Infra.Data.Repository
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

    }
}
