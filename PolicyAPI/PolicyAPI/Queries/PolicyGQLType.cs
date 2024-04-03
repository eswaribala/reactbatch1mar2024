using GraphQL.Types;
using PolicyAPI.Models;

namespace PolicyAPI.Queries
{
    public class PolicyGQLType: ObjectGraphType<Policy>
    {
        public PolicyGQLType()
        {

            Name = "Policy";
            Field(_ => _.PolicyNo).Description("Policy No");
            Field(_ => _.PolicyName).Description("Policy Name");
            Field(_ => _.FromDate).Description("From Date");
            Field(_ => _.ToDate).Description("To Date");
            Field(_ => _.InsuredAmount).Description("Insured Amount");
            Field(_ => _.AdharCardNo).Description("AdharCard No");
            Field(_ => _.RegistrationNo).Description("Vehicle Registration No");
            Field<StringGraphType>("FirstName",
               resolve: context =>
               context.Source.PolicyHolder.Name.FirstName.ToString());
            Field<StringGraphType>("DOB",
               resolve: context =>
               context.Source.PolicyHolder.DOB.ToString());
            Field<StringGraphType>("EngineNo",
               resolve: context =>
               context.Source.Vehicle.EngineNo.ToString());

        }
    }
}
