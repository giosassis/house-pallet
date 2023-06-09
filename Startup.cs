using webApi.Data;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using webApi.Service.Interface;
using webApi.Service.Implementation;
using webApi.Repository.Implementation;
using webApi.Repository.Interface;
using webApi.Repositories.Interfaces;
using webApi.Service.Interfaces;
using webApi.Repositories.Implementations;
using webApi.Service.Implementations;

namespace webApi
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
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string connectionString = $"Server=devenvdb.cqcf1jsxjqpe.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;User Id=postgres;Password={dbPassword}";
            // Configura��o do banco de dados
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(connectionString));

            //Dependence Injection 
            services.AddRepositories();
            services.AddServices();


            // Configura��o do servi�o de mapeamento de objetos
            services.AddAutoMapper(typeof(Startup));

            // Configura��o da sess�o
            services.AddSession(options =>
            {
                options.Cookie.Name = ".webApi.Session";
                options.IdleTimeout = System.TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Adiciona o servi�o MVC
            services.AddControllersWithViews();

            //Swagger Config
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "webApi");
            });
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}