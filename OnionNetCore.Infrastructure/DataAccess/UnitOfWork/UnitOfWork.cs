using OnionNetCore.Core.Interfaces.UnitOfWork;
using OnionNetCore.Infrastructure.DataAccess.Context;

namespace OnionNetCore.Infrastructure.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainContext _context;
        public UnitOfWork(DomainContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
