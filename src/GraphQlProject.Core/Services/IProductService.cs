using GraphQlProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQlProject.Core.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product entity);
        Task<Product> Update(int id, Product entity);
        void Delete(int id);
    }
}
