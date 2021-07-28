using GraphQlProject.Core.Models;
using GraphQlProject.Core.Repositories;
using GraphQlProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQlProject.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository ProductRepository { get; set; }

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await ProductRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await ProductRepository.GetById(id);
        }

        public async Task<Product> Add(Product entity)
        {
            return await ProductRepository.Add(entity);
        }

        public async Task<Product> Update(int id, Product entity)
        {
            var exist = await ProductRepository.GetById(id);
            if (exist == null)
            {
                throw new Exception();
            }

            exist.Name = entity.Name;
            exist.Price = entity.Price;

            return await ProductRepository.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await ProductRepository.GetById(id);
            await ProductRepository.Delete(entity);
        }
    }
}
