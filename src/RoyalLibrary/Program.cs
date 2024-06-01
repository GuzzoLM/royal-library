using System.Reflection;
using RoyalLibrary.WebApplicationUtils;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var codeBase = Assembly.GetExecutingAssembly().Location;
var contentRoot = Path.GetDirectoryName(codeBase);

var config = new ConfigurationBuilder();
config.AddJsonFile(contentRoot + "/appsettings.json", optional: false);
config.AddJsonFile(contentRoot + $"/appsettings.{environment}.json", optional: true);
config.AddEnvironmentVariables();

var configuration = config.Build();

await WebApplication.CreateBuilder(args)
    .UseConfiguration(configuration)
    .ConfigureServices()
    .BuildApp()
    .RunAsync();