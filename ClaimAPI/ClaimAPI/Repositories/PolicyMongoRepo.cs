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
            var _mongoClient= new MongoClient(_configuration["ConnectionString"]);
            var _mongoDatabase=_mongoClient.GetDatabase(_configuration["DatabaseName"]);
            _mongoCollection = _mongoDatabase.GetCollection<Policy>(_configuration["PoliciesCollectionName"]);

        }

        public async void AddPolicy(Policy policy)
        {
            await _mongoCollection.InsertOneAsync(policy);
        }
    }
}
