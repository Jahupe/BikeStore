using BikeStore.Core.CustomEntities;
using BikeStore.Core.Interfaces;
using BikeStore.Core.Services;
using BikeStore.Infrastructure.Data;
using BikeStore.Infrastructure.Interfaces;
using BikeStore.Infrastructure.Options;
using BikeStore.Infrastructure.Repositories;
using BikeStore.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BikeStore.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services,IConfiguration configuration) {
            services.AddDbContext<BikeStoresContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("BikeStore"))
          );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOption>(options => configuration.GetSection("PasswordOption").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddSingleton<IUriServices>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriServices(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BikeStore API",
                    Version = "V1"
                });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                options.IncludeXmlComments(xmlPath);
            });
            return services;
        }


    }
}
