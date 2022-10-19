using Soat.Antigaspi.Application.UseCases.Contracts.Services;

namespace Soat.Antigaspi.Infrastructure.Services;

public class TimeProvider : ITimeProvider
{
    public DateTimeOffset UtcNow()
    {
        return DateTimeOffset.UtcNow;
    }
}