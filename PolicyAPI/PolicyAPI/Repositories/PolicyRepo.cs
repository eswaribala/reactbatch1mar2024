using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public class PolicyRepo : IPolicyRepo
    {
        public Task<Policy> AddPolicy(Policy policy, string adharCardNo)
        {
            throw new NotImplementedException();
        }

        public Task<Policy> DeletePolicy(long policyNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Policy>> GetAllPolicies()
        {
            throw new NotImplementedException();
        }

        public Task<Policy> GetPolicy(long policyNo)
        {
            throw new NotImplementedException();
        }
    }
}
