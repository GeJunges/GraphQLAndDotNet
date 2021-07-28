using GraphQL.Server;
using GraphQL.Types;
using GraphQlProject.Core.Repositories;
using GraphQlProject.Core.Services;
using GraphQlProject.Core.Type;
using GraphQlProject.Infrastructure;
using GraphQlProject.Infrastructure.Configuration;
using GraphQlProject.Mutation;
using GraphQlProject.Query;
using GraphQlProject.Schema;
using GraphQlProject.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQlProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ProductType>();
            services.AddTransient<ProductQuery>();
            services.AddTransient<ProductMutation>();
            services.AddTransient<ISchema, ProductSchema>();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();

            services.AddControllers();

            services.AddDbContext<GraphQlDbContext>(options => options.UseNpgsql(GetDbConnectionString()));
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQlProject", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQlDbContext graphQLDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQlProject v1"));
            }

            graphQLDbContext.Database.EnsureCreated();
            app.UseGraphQLGraphiQL();///ui/graphiql
            app.UseGraphQL<ISchema>();

            app.UseAuthorization();
        }

        private string GetDbConnectionString()
        {
            var configuration = Configuration.GetSection("StorageConfiguration").Get<StorageConfiguration>();
            return $"Server={configuration.Server};Port={configuration.Port};Database={configuration.Database};UserName={configuration.UserName};Password={configuration.Password};";
        }
    }
}
