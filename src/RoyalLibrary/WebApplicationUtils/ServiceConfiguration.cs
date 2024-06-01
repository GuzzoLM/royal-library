using Microsoft.OpenApi.Models;
using RoyalLibrary.DataAccess;
using RoyalLibrary.Domain.Services;

namespace RoyalLibrary.WebApplicationUtils;

public class ServiceConfiguration
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        services.AddControllers();
        services.AddOptions();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            c.EnableAnnotations();
        });

        services.AddLogging();
        services.AddAutoMapper(mapConfig => { mapConfig.AddProfile(new ApiProfile()); });

        var connectionString = configuration["ConnectionString:SqlDatabase"] ??
                               throw new Exception("Missing SQL connection string");

        services.AddDataAccess(connectionString);

        services.AddScoped<IBookService, BookService>();
    }
}