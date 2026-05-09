using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ADOPZ.DataAccess
{
    public static class DataAccessExtentions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuotationContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            services.AddTransiten(typeof(IEfRepository<>), typeof  EfRepostory<>));
            return services;
        }
    }
}
