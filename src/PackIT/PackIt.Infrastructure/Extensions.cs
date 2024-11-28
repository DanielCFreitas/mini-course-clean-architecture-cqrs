using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Infrastructure.EF;
using PackIt.Infrastructure.Logging;
using PackIt.Infrastructure.Services;
using PackIt.Shared.Abstractions.Commands;
using PackIt.Shared.Queries;

namespace PackIt.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddQueries();
        services.AddSingleton<IWeatherApiService, DumbWeatherService>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LogginCommandHandlerDecorator<>));
        return services;
    }
}

