using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Soat.Antigaspi.Application.UseCases.Contracts.Services;
using Soat.Antigaspi.Application.UseCases.Offers;
using Soat.AntiGaspi.Domain.Offers;
using Soat.Antigaspi.Infrastructure.repositories;
using Soat.Antigaspi.Infrastructure.repositories.Repositories;
using Soat.Antigaspi.Infrastructure.Services;

namespace Soat.AntiGaspi.Api.DependencyInjections;

public static class ServiceCollectionExtensions
{

    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateOfferCommand).GetTypeInfo().Assembly);
        services.AddSingleton<ITimeProvider, TimeProvider>();
    }

    public static void AddCustomRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOffers, OffersRepository>();
    }
}