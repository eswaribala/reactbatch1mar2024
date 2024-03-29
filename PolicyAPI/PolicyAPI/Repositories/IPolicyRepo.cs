

using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public interface IPolicyRepo
    {
        Task<Policy> AddPolicy(Policy policy,string adharCardNo);

        Task<Policy> DeletePolicy(long policyNo);
        Task<Policy> GetPolicy(long policyNo);
        Task<IEnumerable<Policy>> GetAllPolicies();

    }
}
