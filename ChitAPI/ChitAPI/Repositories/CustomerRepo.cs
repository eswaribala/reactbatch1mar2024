using ChitAPI.Contexts;
using ChitAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChitAPI.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private ChitContext _context;

        public CustomerRepo(ChitContext chitContext)
        {
            _context = chitContext;
        }

        public async Task<Customer> AddCustomer(Customer Customer)
        {
            var result = await this._context.Customers.AddAsync(Customer);

            await this._context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteCustomer(long Id)
        {
            var result = await this._context.Customers.FirstOrDefaultAsync(c =>
           c.Id == Id);
            if (result != null)
            {
                this._context.Customers.Remove(result);
                await this._context.SaveChangesAsync();
            }

            result = await this._context.Customers.FirstOrDefaultAsync(c =>
            c.Id == Id);
            if (result == null)
                return true;
            else
                return false;
        }

        public async Task<Customer> GetCustomerById(long Id)
        {
            var result = await this._context.Customers.FirstOrDefaultAsync(c =>
        c.Id == Id);
            if (result != null)
                return result;
            else
                return null;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await this._context.Customers.ToListAsync();
        }

        public async Task<Customer> LoginValidation(string email, string Password)
        {
            var result = await this._context.Customers.FirstOrDefaultAsync(c =>
      c.Email == email && c.Password == Password);
            if (result != null)
                return result;
            else
                return null;
        }

        public async Task<Customer> UpdateCustomer(long Id, long Phone)
        {
            var result = await this._context.Customers.FirstOrDefaultAsync(c =>
           c.Id == Id);
            if (result != null)
            {
                result.Phone = Phone;
                await this._context.SaveChangesAsync();
                return result;

            }
            else
                return null;
        }
    }
}
