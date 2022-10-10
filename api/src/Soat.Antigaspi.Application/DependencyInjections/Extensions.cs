using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Soat.Antigaspi.Application.UseCases.Offers;

namespace Soat.Antigaspi.Application.DependencyInjections;

public static class ServiceCollectionExtensions
{

    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateOfferCommand).GetTypeInfo().Assembly);
    }
}