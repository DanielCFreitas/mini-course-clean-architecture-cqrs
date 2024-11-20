using PackIt.Application.DTO.External;
using PackIt.Domain.ValueObjects;

namespace PackIt.Application.Services;

public interface IWeatherApiService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}