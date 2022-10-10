

using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Soat.AntiGaspi.Application.DependencyInjections
{
    
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions));
        }
    }    
};
