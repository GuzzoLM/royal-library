using Microsoft.EntityFrameworkCore;
using RoyalLibrary.DataAccess.Repositories;
using RoyalLibrary.Domain.Repositories;

namespace RoyalLibrary.DataAccess;

public static class DataAccessRegistry
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LibraryContext>(
            options => options
                .UseSqlServer(connectionString, a => a.CommandTimeout(180))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging());

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}