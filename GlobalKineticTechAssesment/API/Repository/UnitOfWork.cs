using API.Repository.Entities;
using System.Threading.Tasks;

namespace API.Repository
{
    /// <summary>
    /// Unit of Work To create repositories in this case only 1
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private IRepository<CoinEntity> coinRepository;
        public IRepository<CoinEntity> CoinRepository => coinRepository ?? new Repository<CoinEntity>(_context);

        void IUnitOfWork.SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
