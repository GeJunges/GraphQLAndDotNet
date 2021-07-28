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
            FieldAsync<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: async context =>
                 {
                     return await productService.Add(context.GetArgument<Product>("product"));
                 });

            FieldAsync<ProductType>("updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: async context =>
                {
                    return await productService.Update(
                        context.GetArgument<int>("id"),
                        context.GetArgument<Product>("product"));
                });


            FieldAsync<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                 {
                     var id = context.GetArgument<int>("id");
                     await productService.Delete(id);
                     return $"Product {id} has been deleted";
                 });
        }
    }
}
