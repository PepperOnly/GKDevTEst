namespace API.Interfaces
{
    /// <summary>
    /// Given Interface not allowed to change
    /// </summary>
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}
