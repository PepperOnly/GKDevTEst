using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();        
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> DeletAll()
        {
            var list = await _context.Set<T>().ToListAsync();
            foreach(var item in list)
            {
                _context.Set<T>().Remove(item);
            }
            return list.Count;
        }
    }
}
