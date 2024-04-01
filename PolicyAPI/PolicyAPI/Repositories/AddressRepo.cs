

using Microsoft.EntityFrameworkCore;
using PolicyAPI.Contexts;
using PolicyAPI.Models;
using PolicyAPI.Repositories;

namespace AddressAPI.Repositories
{
    public class AddressRepo:IAddressRepo
    {
        private PolicyContext _dbContext;

        public AddressRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Address> AddAddress(Address Address, string adharCardNo)
        {

            PolicyHolder PolicyHolder = await IsPolicyHolderExists(adharCardNo);
          
            if (PolicyHolder != null) 
            {

                Address.PolicyHolder = PolicyHolder;
              
                var result = await this._dbContext.Addresses.AddAsync(Address);
                await this._dbContext.SaveChangesAsync();
                return result.Entity;

            }
            else
            {
                return null;
            }



        }

        private async Task<PolicyHolder> IsPolicyHolderExists(string adharCardNo)
        {

            return await this._dbContext.PolicyHolders.FirstOrDefaultAsync(p => p.AdharCardNo == adharCardNo);

        }



        private async Task<Address> IsAddressExists(string doorNo, string streetName)
        {

            return await this._dbContext.Addresses
                .FirstOrDefaultAsync(a => a.DoorNo == doorNo && a.StreetName==streetName);

        }

        public async Task<bool> DeleteAddress(string doorNo, string streetName)
        {
            bool Status = false;
            var result = await IsAddressExists(doorNo,streetName);
            if (result != null)
            {
                this._dbContext.Addresses.Remove(result);
                await this._dbContext.SaveChangesAsync();
                Status = true;
            }

            return Status;

        }




        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await this._dbContext.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddress(string doorNo, string streetName)
        {
            return await IsAddressExists(doorNo, streetName);
        }


        public async Task<Address> UpdateAddress(Address address, string oldDoorNo, string oldStreetName)
        {
            var result = await IsAddressExists(oldDoorNo,oldStreetName);
            if (result != null)
            {
                result.DoorNo=address.DoorNo;
                result.StreetName=address.StreetName;
                result.City=address.City;
                result.State=address.State;
                result.PostalCode=address.PostalCode;
                result.Country=address.Country;
                await this._dbContext.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }

        }

       
    }
}
