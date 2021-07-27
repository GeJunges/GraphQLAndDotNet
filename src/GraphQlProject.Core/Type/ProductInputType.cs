using GraphQL.Types;

namespace GraphQlProject.Core.Type
{
    public class ProductInputType : InputObjectGraphType
    {

        public ProductInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("price");
        }
    }
}
