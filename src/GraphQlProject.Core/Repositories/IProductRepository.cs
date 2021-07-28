using GraphQlProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQlProject.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product entity);
        Task<Product> Update(Product entity);
        void Delete(Product entity);
    }
}
