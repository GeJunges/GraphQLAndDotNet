using GraphQlProject.Core.Models;
using GraphQlProject.Core.Repositories;
using GraphQlProject.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQlProject.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public GraphQlDbContext DbContext { get; set; }

        public ProductRepository(GraphQlDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await DbContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await DbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Add(Product entity)
        {
            await DbContext.Products.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Update(Product entity)
        {
            DbContext.Products.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(Product entity)
        {
            DbContext.Products.Remove(entity);
            DbContext.SaveChanges();
        }
    }
}
