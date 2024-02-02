using Hapvida.Core.Infra.OpenTelemetry.Exporter.Collector;
using Hapvida.Digital.Beneficiary.Admin.Api;
using Microsoft.FeatureManagement;
var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

try {
    var connectionString = Environment.GetEnvironmentVariable("AzureAppConfigConnectionString");
    builder.Configuration.AddAzureAppConfiguration(options => {
        options.Connect(connectionString);
        options.UseFeatureFlags(
            featureFlagOptions => {
                featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(1);
            }
        );
    });
    logger.LogInformation("Azure App Configuration loaded successfully.");
}
catch (Exception ex)
{
    logger.LogError(ex, "Azure App Configuration failed to load.");
}
var configuration = builder.Configuration;

builder.Services.AddAppContext<Program>(configuration);
builder.Services.AddDomainContext(configuration);

builder.Services.AddOpenTelemetryContext(configuration);
builder.Services.AddAzureAppConfiguration();
builder.Services.AddFeatureManagement();
builder.Services.AddApplicationRepository();


var app = builder.Build();
app.UseApplicationContext();
app.UseAzureAppConfiguration();
app.Run();