using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public interface IAddressRepo
    {
        Task<Address> AddAddress(Address Address, string adharCardNo);

        Task<Address> UpdateAddress(Address address,
            string oldDoorNo, string oldStreetName);
        Task<bool> DeleteAddress(string doorNo, string streetName);
        Task<Address> GetAddress(string doorNo, string streetName);
        Task<IEnumerable<Address>> GetAllAddresses();

    }
}
