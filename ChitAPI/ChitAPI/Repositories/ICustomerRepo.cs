using ChitAPI.Models;

namespace ChitAPI.Repositories
{
    public interface ICustomerRepo
    {
        Task<Customer> AddCustomer(Customer Customer);
        Task<Customer> UpdateCustomer(long Id, long Phone);
        Task<bool> DeleteCustomer(long Id);
        Task<Customer> GetCustomerById(long Id);
        Task<Customer> LoginValidation(String email, String Password);
        Task<IEnumerable<Customer>> GetCustomers();

    }
}
