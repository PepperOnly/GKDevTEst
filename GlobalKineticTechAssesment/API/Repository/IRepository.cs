
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository
{
    /// <summary>
    /// Generic Database calls for all Entities
    /// </summary>
    /// <typeparam name="T">Type of Entity to manipulate -> Table in DB</typeparam>
    public interface IRepository<T> where T : class, new()
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> DeletAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);        
    }
}
