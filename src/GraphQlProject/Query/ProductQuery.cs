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
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAll(); });
            Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    return productService.GetById(context.GetArgument<int>("id"));
                });
        }
    }
}
