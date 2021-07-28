using GraphQL;
using GraphQL.Types;
using GraphQlProject.Core.Services;
using GraphQlProject.Core.Type;

namespace GraphQlProject.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            FieldAsync<ListGraphType<ProductType>>("products",
                resolve: async context => { return await productService.GetAll(); });
            FieldAsync<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    return await productService.GetById(context.GetArgument<int>("id"));
                });
        }
    }
}
