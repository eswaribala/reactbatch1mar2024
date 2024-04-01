using Microsoft.EntityFrameworkCore;
using PolicyAPI.Contexts;
using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public class PolicyHolderRepo : IPolicyHolderRepo
    {
        private PolicyContext _dbContext;

        public PolicyHolderRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder)
        {
            var result = await this._dbContext.PolicyHolders.AddAsync(policyHolder);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<bool> DeletePolicyHolder(string adharCardNo)
        {
            bool Status = false;
            var result = await IsPolicyHolderExists(adharCardNo.Trim());
            if (result != null)
            {
                this._dbContext.PolicyHolders.Remove(result);
                await this._dbContext.SaveChangesAsync();
                Status = true;
            }

            return Status;

        }


        private async Task<PolicyHolder> IsPolicyHolderExists(string adharCardNo)
        {

            return await this._dbContext.PolicyHolders.FirstOrDefaultAsync(p => p.AdharCardNo == adharCardNo);

        }

        public async Task<IEnumerable<PolicyHolder>> GetAllPolicyHolders()
        {
            return await this._dbContext.PolicyHolders.ToListAsync();
        }

        public async Task<PolicyHolder> GetPolicyHolder(string adharCardNo)
        {
            return await IsPolicyHolderExists(adharCardNo);
        }

        public async Task<PolicyHolder> UpdatePolicyHolder(string adharCardNo, string newEmail, long newMobilrNo)
        {
            var result = await IsPolicyHolderExists(adharCardNo);
            if (result != null)
            {
                result.Email = newEmail;
                result.Phone = newMobilrNo;
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
