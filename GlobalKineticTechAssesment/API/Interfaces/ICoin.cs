namespace API.Interfaces
{
    /// <summary>
    /// Given Interface not allowed to change
    /// </summary>
    public interface ICoin
    {
        decimal Amount { get; set; }
        decimal Volume { get; set; }
    }
}
