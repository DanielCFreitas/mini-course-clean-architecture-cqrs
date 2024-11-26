using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Domain.Repositories;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Options;
using PackIt.Infrastructure.EF.Repositories;
using PackIt.Infrastructure.EF.Services;
using PackIt.Shared.Options;

namespace PackIt.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPackingListRepository, PostgresPackintListRepository>();
        services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();
        
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
        return services;
    }
}