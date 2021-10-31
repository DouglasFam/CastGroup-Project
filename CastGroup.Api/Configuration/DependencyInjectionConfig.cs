using CastGroup.Domain.Interface.IRepository;
using CastGroup.Domain.Interface.IService;
using CastGroup.Infra.Data.Context;
using CastGroup.Infra.Data.Repository;
using CastGroup.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CastGroup.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ApiDbContext>();

            return services;
        }
    }
}
