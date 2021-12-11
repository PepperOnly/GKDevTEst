
using API.Enums;

namespace API.Repository.Entities
{    
    public class CoinEntity
    {
        public int Id { get; set; }
        public decimal Ammount { get; set; }
        public decimal Volume { get; set; }
        public Type Type { get; set; }
    }
}
