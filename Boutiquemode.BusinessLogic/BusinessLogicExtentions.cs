using System;
using System.Collections.Generic;
using System.Text;

namespace ADOPZ.BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(
                cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddDataAccessServices(configuration);
            return services;
        }
    }
}
