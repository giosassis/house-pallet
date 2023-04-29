using webApi.Repositories.Implementations;
using webApi.Repositories.Interfaces;
using webApi.Repository.Implementation;
using webApi.Repository.Interface;
using webApi.Service.Implementation;
using webApi.Service.Implementations;
using webApi.Service.Interface;
using webApi.Service.Interfaces;

namespace webApi
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }


    }
}
