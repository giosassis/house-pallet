using webApi.Repositories.Implementations;
using webApi.Repositories.Interfaces;
using webApi.Repository.Implementation;
using webApi.Repository.Interface;
using webApi.Service.Implementation;
using webApi.Service.Implementations;
using webApi.Service.Interface;
using webApi.Service.Interfaces;
using WebApi.Repositories.Implementations;
using WebApi.Repository.Implementation;
using WebApi.Service.Interface;

namespace webApi
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDeliveryAddressRepository, DeliveryAddressRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDeliveryAddressService, DeliveryAddressService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
        }


    }
}
