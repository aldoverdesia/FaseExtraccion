using FaseExtraccion.BLL.Service;
using FaseExtraccion.DAL;
using FaseExtraccion.DAL.DBManager;
using FaseExtracion.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;

namespace FaseExtraccion.Extension
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<FaseExtraccionContext>(o =>
                 o.UseSqlServer(configuration.GetConnectionString("FaseExtraccionConnection")), ServiceLifetime.Transient);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFaseService, FaseService>();
            return services;
        }

    }
}
