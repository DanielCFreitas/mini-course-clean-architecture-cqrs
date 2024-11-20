using PackIt.Domain.ValueObjects;
using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions;

public class MissingLocalizationWeatherException(Localization localization)
    : PackItException($"Counld't fetch weather data for localization ${localization.Country}/${localization.City}")
{
}