using Microsoft.EntityFrameworkCore;
using PolicyAPI.Contexts;
using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public class PolicyRepo : IPolicyRepo
    {
        private PolicyContext _dbContext;

        public PolicyRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Policy> AddPolicy(Policy Policy,string adharCardNo, string registrationNo)
        {

            PolicyHolder policyHolder = await IsPolicyHolderExists(adharCardNo);
            Vehicle vehicle = await IsVehicleExists(registrationNo);
            if((policyHolder !=null) && (vehicle != null)) {

                Policy.PolicyHolder = policyHolder;
                Policy.Vehicle = vehicle;
                var result = await this._dbContext.Policies.AddAsync(Policy);
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

        private async Task<Vehicle> IsVehicleExists(string registrationNo)
        {

            return await this._dbContext.Vehicles.FirstOrDefaultAsync(v => v.RegistrationNo == registrationNo);

        }

        private async Task<Policy> IsPolicyExists(long policyNo)
        {

            return await this._dbContext.Policies.FirstOrDefaultAsync(p => p.PolicyNo == policyNo);

        }

        public async Task<bool> DeletePolicy(long policyNo)
        {
            bool Status = false;
            var result = await IsPolicyExists(policyNo);
            if (result != null)
            {
                this._dbContext.Policies.Remove(result);
                await this._dbContext.SaveChangesAsync();
                Status = true;
            }

            return Status;

        }


        

        public async Task<IEnumerable<Policy>> GetAllPolicies()
        {
            return await this._dbContext.Policies
                .Include(p=>p.PolicyHolder)
                .Include(p=>p.Vehicle)
                .ToListAsync();
        }

        public async Task<Policy> GetPolicy(long policyNo)
        {
            return await IsPolicyExists(policyNo);
        }

        
    }
}
