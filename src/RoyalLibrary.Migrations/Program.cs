using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RoyalLibrary.Migrations.Migrations;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var codeBase = Assembly.GetExecutingAssembly().Location;
var contentRoot = Path.GetDirectoryName(codeBase);

var config = new ConfigurationBuilder();
config.AddJsonFile(contentRoot + "/appsettings.json", optional: false);
config.AddJsonFile(contentRoot + $"/appsettings.{environment}.json", optional: true);
config.AddEnvironmentVariables();

var configuration = config.Build();

var services = new ServiceCollection();

services.AddFluentMigratorCore()
    .ConfigureRunner(builder =>
    {
        var connectionString = configuration["ConnectionString:SqlDatabase"];

        builder
            .AddSqlServer()
            .WithGlobalConnectionString(connectionString)
            .WithGlobalCommandTimeout(TimeSpan.Zero)
            .ScanIn(typeof(Migration_2024_06_01_1018_Create_BooksTable).Assembly).For.Migrations();
    });

services.AddLogging(builder =>
{
    builder.AddDebug();
    builder.AddConsole();
});

var container = services.BuildServiceProvider();

var logger = container.GetRequiredService<ILogger<Program>>();
var migrationRunner = container.GetRequiredService<IMigrationRunner>();

try
{
    logger.LogInformation("Running migrations");
    migrationRunner.MigrateUp();
}
catch (Exception e)
{
    Console.WriteLine(e);
}