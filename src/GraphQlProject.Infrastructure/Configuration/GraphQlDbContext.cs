using GraphQlProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlProject.Infrastructure.Configuration
{
    public class GraphQlDbContext : DbContext
    {
        public GraphQlDbContext(DbContextOptions<GraphQlDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
