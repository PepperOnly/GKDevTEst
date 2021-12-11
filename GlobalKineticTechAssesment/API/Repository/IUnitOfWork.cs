using API.Repository.Entities;
using System;
using System.Threading.Tasks;

namespace API.Repository
{
    /// <summary>
    /// Load repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CoinEntity> CoinRepository { get; }
        void SaveChanges();
    }
}
