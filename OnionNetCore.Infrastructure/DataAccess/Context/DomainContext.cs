using Microsoft.EntityFrameworkCore;
using OnionNetCore.Core.Entities;

namespace OnionNetCore.Infrastructure.DataAccess.Context
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users{ get; set; }

    }
}
