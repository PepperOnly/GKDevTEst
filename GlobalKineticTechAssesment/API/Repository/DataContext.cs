using API.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    /// <summary>
    /// Data Context for Database
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CoinEntity> Coins { get; set; }
        //public DbSet<CoinJarEntity> CoinJars { get; set; }
    }
}
