using ClaimAPI.Models;

namespace ClaimAPI.Repositories
{
    public interface IPolicyMongoRepo
    {
        void AddPolicy(Policy policy);
    }
}
