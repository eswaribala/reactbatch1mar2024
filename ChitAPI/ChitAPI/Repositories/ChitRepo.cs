using ChitAPI.Contexts;
using ChitAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ChitAPI.Repositories
{
    public class ChitRepo : IChitRepo
    {
        private ChitContext _context;
        public ChitRepo(ChitContext chitContext) { 
            this._context = chitContext;

        }
        public async Task<Chit> AddChit(Chit Chit, long CustomerId)
        {
            Customer? result = await this._context.Customers.FirstOrDefaultAsync(c =>
        c.Id == CustomerId);

            if (result != null)
            {
                Chit.Customer = result;
                var chitResult = await this._context.Chits.AddAsync(Chit);
                await this._context.SaveChangesAsync();
                return chitResult.Entity;
            }
            else
                return null;
        }

        public async Task<bool> DeleteChit(long ChitId)
        {
            var result = await this._context.Chits.FirstOrDefaultAsync(c =>
          c.ChitId == ChitId);
            if (result != null)
            {
                this._context.Chits.Remove(result);
                await this._context.SaveChangesAsync();
            }

            result = await this._context.Chits.FirstOrDefaultAsync(c =>
            c.ChitId == ChitId);
            if (result == null)
                return true;
            else
                return false;


        }

        public async Task<Chit> GetChitByChitId(long ChitId)
        {
            var result = await this._context.Chits.FirstOrDefaultAsync(c =>
       c.ChitId == ChitId);
            if (result != null)
                return result;
            else
                return null;
        }

        public async Task<IEnumerable<Chit>> GetChits()
        {
            return await this._context.Chits.ToListAsync();
        }

        public async Task<Chit> UpdateChit(long ChitId, int Duration)
        {
            var result = await this._context.Chits.FirstOrDefaultAsync(c =>
          c.ChitId == ChitId);
            if (result != null)
            {
                result.TotalDuration= Duration;
                await this._context.SaveChangesAsync();
                return result;

            }
            else
                return null;
        }
    }
}
