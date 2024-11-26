using PackIt.Application.DTO.External;
using PackIt.Application.Services;
using PackIt.Domain.ValueObjects;

namespace PackIt.Infrastructure.Services;

internal sealed class DumbWeatherService : IWeatherApiService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization)
        => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
}