namespace RoyalLibrary.WebApplicationUtils;

public static class WebApplicationExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        var configure = new ServiceConfiguration();

        configure.Configure(builder.Services, builder.Configuration);

        return builder;
    }

    public static WebApplicationBuilder UseConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.WebHost.UseConfiguration(configuration);

        return builder;
    }

    public static WebApplication BuildApp(this WebApplicationBuilder builder)
    {
        var app = builder.Build();

        var configure = new ApplicationConfiguration();

        configure.Configure(app, builder.Configuration);

        return app;
    }
}