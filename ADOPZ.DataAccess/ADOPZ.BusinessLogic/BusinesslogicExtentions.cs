using ADOPZ.DataAccess; // Para AddDataAccessServices
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ADOPZ.BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static object TypeAdapterConfig { get; private set; }

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            // Inyección de la capa de Datos (Asegúrate que este método exista en ADOPZ.DataAccess)
            services.AddDataAccessServices(configuration);

            // Configuración de Mapster
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}