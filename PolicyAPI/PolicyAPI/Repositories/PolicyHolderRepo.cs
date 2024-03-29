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


        public Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder)
        {
            throw new NotImplementedException();
        }

        public Task<PolicyHolder> DeletePolicyHolder(string adharCardNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PolicyHolder>> GetAllPolicyHolders()
        {
            throw new NotImplementedException();
        }

        public Task<PolicyHolder> GetPolicyHolder(string adharCardNo)
        {
            throw new NotImplementedException();
        }

        public Task<PolicyHolder> UpdatePolicyHolder(string adharCardNo, string newEmail, long newMobilrNo)
        {
            throw new NotImplementedException();
        }
    }
}
