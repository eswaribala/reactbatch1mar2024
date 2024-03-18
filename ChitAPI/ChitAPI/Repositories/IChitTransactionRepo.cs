using ChitAPI.Models;

namespace ChitAPI.Repositories
{
    public interface IChitTransactionRepo
    {
        Task<ChitTransaction> AddChitTransaction(ChitTransaction ChitTransaction, long ChitId);
        Task<ChitTransaction> UpdateChitTransaction(long ChitTransactionId, long DueAmount);
        Task<bool> DeleteChitTransaction(long ChitTransactionId);
        Task<ChitTransaction> GetChitTransactionByChitTransactionId(long ChitTransactionId);
        Task<IEnumerable<ChitTransaction>> GetChitTransactions();
    }
}
