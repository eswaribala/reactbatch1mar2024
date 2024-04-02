using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using PolicyAPI.Models;
using PolicyAPI.Repositories;

namespace PolicyAPI.Queries
{
    public class RootQuery:ObjectGraphType
    {
        public RootQuery(IVehicleRepo vehicleRepo,
            IPolicyHolderRepo policyHolderRepo,
            IPolicyRepo policyRepo, IAddressRepo addressRepo)
        {
            Field<ListGraphType<VehicleGQLType>>(
                Name = "vehicles",
                resolve: context => vehicleRepo.GetAllVehicles()

                );

            Field<VehicleGQLType>(
                Name = "vehicle",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>
                {
                    Name = "registrationNo"
                }),
                resolve: context => vehicleRepo
                .GetVehicle(context.GetArgument<string>("registrationNo")));


            Field<ListGraphType<PolicyHolderGQLType>>(
                Name = "policyholders",
                resolve: context => policyHolderRepo.GetAllPolicyHolders()

                );

            Field<PolicyHolderGQLType>(
                Name = "policyholder",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>
                {
                    Name = "adharCardNo"
                }),
                resolve: context => policyHolderRepo.GetPolicyHolder(context
                .GetArgument<string>("adharCardNo")
                )

                );


            Field<ListGraphType<PolicyGQLType>>(
                Name = "policies",
                resolve: context => policyRepo.GetAllPolicies()
                );
            Field<PolicyGQLType>(
                Name = "policy",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>{
                    Name = "policyNo"
                }),
                resolve: context => policyRepo.
                GetPolicy(context.GetArgument<long>("policyNo"))
                );

            Field<ListGraphType<AddressGQLType>>(
                Name="addresses",
                resolve: context =>addressRepo.GetAllAddresses()
                );


            Field<AddressGQLType>(
                Name = "address",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>
                {
                    Name = "doorNo"
                },
                new QueryArgument<StringGraphType>
                {
                    Name = "streetName"
                },
                new QueryArgument<StringGraphType>
                {
                    Name = "adharCardNo"
                }


                ),
                resolve: context => addressRepo.
                GetAddress(context.GetArgument<string>("doorNo"),
                context.GetArgument<string>("streetName"),
                context.GetArgument<string>("adharCardNo"))
                );


        }
    }
}
