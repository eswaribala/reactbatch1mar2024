using GraphQL.Types;
using PolicyAPI.Models;

namespace PolicyAPI.Queries
{
    public class GenderGQlType:EnumerationGraphType<Gender>
    {
         public GenderGQlType()
        {
            Name = "gender";
        }
    }
}
