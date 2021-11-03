using HotelListing.IRepository;
using System;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.IRepository;

namespace WebApplication1.Repository
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly DatabaseContext _context;

        private IGenericRepository<User> _users;
        private IGenericRepository<Device> _devices;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Device> Devices => _devices ??= new GenericRepository<Device>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
  
        }
    }
}
