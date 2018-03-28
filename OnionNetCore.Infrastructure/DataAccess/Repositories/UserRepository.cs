using OnionNetCore.Core.Entities;
using OnionNetCore.Core.Interfaces.Repositories;
using OnionNetCore.Infrastructure.DataAccess.Context;

namespace OnionNetCore.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DomainContext context) : base(context)
        {
        }
    }
}
