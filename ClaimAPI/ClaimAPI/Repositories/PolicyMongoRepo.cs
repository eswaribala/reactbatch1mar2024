using ClaimAPI.Models;
using MongoDB.Driver;

namespace ClaimAPI.Repositories
{
    public class PolicyMongoRepo : IPolicyMongoRepo
    {
        private IConfiguration _configuration;
        private IMongoCollection<Policy> _mongoCollection;

        public PolicyMongoRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddPolicy(Policy policy)
        {
            throw new NotImplementedException();
        }
    }
}
