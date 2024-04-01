

using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public interface IPolicyRepo
    {
        Task<Policy> AddPolicy(Policy policy,string adharCardNo,string registrationNo);

        Task<bool> DeletePolicy(long policyNo);
        Task<Policy> GetPolicy(long policyNo);
        Task<IEnumerable<Policy>> GetAllPolicies();

    }
}
