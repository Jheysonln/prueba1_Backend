using DataAcces;
using DataAccesInterface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba1_Backend.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
        {
            services.AddTransient<IMUsuario, UsuarioDA>();
            return services;
        }
    }
}
