using GraphQL;
using GraphQL.Types;
using GraphQlProject.Core.Models;
using GraphQlProject.Core.Services;
using GraphQlProject.Core.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlProject.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    return productService.Add(context.GetArgument<Product>("product"));
                });

            Field<ProductType>("updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    return productService.Update(
                        context.GetArgument<int>("id"),
                        context.GetArgument<Product>("product"));
                });


            Field<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    productService.Delete(id);
                    return $"Product {id} has been deleted";
                });
        }
    }
}
