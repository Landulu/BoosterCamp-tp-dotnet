using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Soat.Antigaspi.Application.UseCases.Offers;
using Soat.AntiGaspi.Domain.Offers;
using Soat.Antigaspi.Infrastructure.repositories;

namespace Soat.AntiGaspi.Api.DependencyInjections;

public static class ServiceCollectionExtensions
{

    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateOfferCommand).GetTypeInfo().Assembly);
    }

    public static void AddCustomRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOffers, OffersRepository>();
    }
}