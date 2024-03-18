using ChitAPI.Models;

namespace ChitAPI.Repositories
{
    public interface IChitRepo
    {
        Task<Chit> AddChit(Chit Chit,long CustomerId);
        Task<Chit> UpdateChit(long ChitId, int Duration);
        Task<bool> DeleteChit(long ChitId);
        Task<Chit> GetChitByChitId(long ChitId);
        Task<IEnumerable<Chit>> GetChits();
    }
}
