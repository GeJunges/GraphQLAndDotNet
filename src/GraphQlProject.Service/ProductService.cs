using GraphQlProject.Core.Models;
using GraphQlProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlProject.Service
{
    public class ProductService : IProductService
    {
        private static List<Product> Products = new List<Product>
        {
            new Product{ Id = 1, Name = "Coffie", Price =10},
            new Product{ Id = 2, Name = "Tea", Price =15},
            new Product{ Id = 3, Name = "Chocolate", Price =3}
        };

        public Task<Product> Add(Product entity)
        {
            Products.Add(entity);
            return Task.FromResult(entity);
        }

        public void Delete(int id)
        {
            Products.RemoveAt(id);
        }

        public Task<List<Product>> GetAll()
        {
            return Task.FromResult(Products);
        }

        public Task<Product> GetById(int id)
        {
            var entity = Products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(entity);
        }

        public Task<Product> Update(int id, Product entity)
        {
            Products[id] = entity;
            return Task.FromResult(entity);
        }
    }
}
