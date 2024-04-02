using GraphQL;
using GraphQL.Types;
using PolicyAPI.Repositories;

namespace PolicyAPI.Queries
{
    public class RootQuery:ObjectGraphType
    {
        public RootQuery(IVehicleRepo vehicleRepo)
        {
            Field<ListGraphType<VehicleGQLType>>(
                Name = "vehicles",
                resolve: context => vehicleRepo.GetAllVehicles()

                ) ;

            Field<VehicleGQLType>(
                Name = "vehicle",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>
                {
                    Name = "registrationNo"
                }),
                resolve: context => vehicleRepo
                .GetVehicle(context.GetArgument<string>("registrationNo")));


        }
    }
}
