using GraphQL.Types;
using PolicyAPI.Models;

namespace PolicyAPI.Queries
{
    public class FuelGLType : EnumerationGraphType<FuelType>
    {

        public FuelGLType()
        {
            Name = "fueltype";
        }
    }
}
