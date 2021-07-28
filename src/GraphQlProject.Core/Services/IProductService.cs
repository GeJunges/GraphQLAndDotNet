using GraphQlProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQlProject.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product entity);
        Task<Product> Update(int id, Product entity);
        Task Delete(int id);
    }
}
