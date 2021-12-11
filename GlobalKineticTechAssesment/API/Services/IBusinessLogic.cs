

using API.Enums;

namespace API.Services
{
    public interface IBusinessLogic
    {
        void AddCoin(Type type);
        decimal GetTotalAmount();
        void Reset();
    }
}
