using GraphQL.Types;
using GraphQlProject.Core.Models;

namespace GraphQlProject.Core.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.Price);
        }
    }
}
