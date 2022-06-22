using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration 
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IWriteCustomerRepository,WriteCustomerRepository>();
            services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
            services.AddScoped<IWriteProductRepository, WriteProductRepository>();
            services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
            services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
            services.AddScoped<IReadProductRepository, ReadProductRepository>();
        }
    }
}
