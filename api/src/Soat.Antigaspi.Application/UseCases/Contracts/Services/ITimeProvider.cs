namespace Soat.Antigaspi.Application.UseCases.Contracts.Services;

public interface ITimeProvider
{
    public DateTimeOffset UtcNow();
}