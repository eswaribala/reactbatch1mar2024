using ChitAPI.Contexts;
using ChitAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChitAPI.Repositories
{
    public class ChitTransactionRepo : IChitTransactionRepo
    {
        private ChitContext _context;
        public ChitTransactionRepo(ChitContext chitContext)
        {
            this._context = chitContext;

        }
        public async Task<ChitTransaction> AddChitTransaction(ChitTransaction ChitTransaction, long ChitId)
        {
            Chit? result = await this._context.Chits.FirstOrDefaultAsync(c =>
        c.ChitId == ChitId);

            if (result != null)
            {
                ChitTransaction.Chit = result;
                var chitTransactionResult = await this._context.ChitTransactions.AddAsync(ChitTransaction);
                await this._context.SaveChangesAsync();
                return chitTransactionResult.Entity;
            }
            else
                return null;
        }

        public async Task<bool> DeleteChitTransaction(long ChitTransactionId)
        {
            var result = await this._context.ChitTransactions.FirstOrDefaultAsync(c =>
          c.TransactionId == ChitTransactionId);
            if (result != null)
            {
                this._context.ChitTransactions.Remove(result);
                await this._context.SaveChangesAsync();
            }

            result = await this._context.ChitTransactions.FirstOrDefaultAsync(c =>
            c.TransactionId == ChitTransactionId);
            if (result == null)
                return true;
            else
                return false;


        }

        public async Task<ChitTransaction> GetChitTransactionByChitTransactionId(long ChitTransactionId)
        {
            var result = await this._context.ChitTransactions.FirstOrDefaultAsync(c =>
       c.TransactionId == ChitTransactionId);
            if (result != null)
                return result;
            else
                return null;
        }

        public async Task<IEnumerable<ChitTransaction>> GetChitTransactions()
        {
            return await this._context.ChitTransactions.ToListAsync();
        }

        public async Task<ChitTransaction> UpdateChitTransaction(long ChitTransactionId, long DueAmount)
        {
            var result = await this._context.ChitTransactions.FirstOrDefaultAsync(c =>
          c.TransactionId == ChitTransactionId);
            if (result != null)
            {
                result.DueAmount = DueAmount;
                await this._context.SaveChangesAsync();
                return result;

            }
            else
                return null;
        }

        
        
    }
}
