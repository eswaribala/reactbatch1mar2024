using GraphQL.Types;
using PolicyAPI.Queries;
namespace PolicyAPI.Schemas
{
    public class PolicySchema:Schema
    {

        public PolicySchema(IServiceProvider serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
        }
    }
}
