using GraphQL.Types;
using PolicyAPI.Models;

namespace PolicyAPI.Queries
{
    public class VehicleGQLType:ObjectGraphType<Vehicle>
    {

        public VehicleGQLType()
        {
            Name = "vehicle";
            Field(_ => _.RegistrationNo).Description("Registration No");
            Field(_ => _.EngineNo).Description("Engine No");
            Field(_ => _.ChasisNo).Description("Chassis No");
            Field(_ => _.DOR).Description("Registration Date");
            Field<StringGraphType>("fuelType",
                resolve: context =>
                context.Source.FuelType.ToString());
            Field(_ => _.Color).Description("Color");
            Field(_ => _.Maker).Description("Maker");

        }
    }
}
