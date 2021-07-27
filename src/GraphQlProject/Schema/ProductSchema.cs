using GraphQlProject.Mutation;
using GraphQlProject.Query;

namespace GraphQlProject.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMudation)
        {
            Query = productQuery;
            Mutation = productMudation;
        }
    }
}
