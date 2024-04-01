using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public interface IPolicyHolderRepo
    {
        Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder);

        Task<PolicyHolder> UpdatePolicyHolder(string adharCardNo,
            string newEmail, long newMobileNo);
        Task<bool> DeletePolicyHolder(string adharCardNo);
        Task<PolicyHolder> GetPolicyHolder(string adharCardNo);
        Task<IEnumerable<PolicyHolder>> GetAllPolicyHolders();

    }
}
