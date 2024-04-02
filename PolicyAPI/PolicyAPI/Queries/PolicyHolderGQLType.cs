using GraphQL.Types;
using PolicyAPI.Models;

namespace PolicyAPI.Queries
{
    public class PolicyHolderGQLType:ObjectGraphType<PolicyHolder>
    {

        public PolicyHolderGQLType()
        {
            Name = "PolicyHolder";
            Field(_ => _.AdharCardNo).Description("Adhard Card No");
            Field(_ => _.Name.FirstName).Description("First Name");
            Field(_ => _.Name.LastName).Description("Last Name");
            Field(_ => _.Name.MiddleName).Description("Middle Name");
            Field(_ => _.DOB).Description("Date of Birth");
            Field(_ => _.Email).Description("Email");
            Field(_ => _.Phone).Description("Mobile No");
            Field<StringGraphType>("gender",
                resolve: context =>
                context.Source.Gender.ToString());
        }
    }
}
