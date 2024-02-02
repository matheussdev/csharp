namespace Hapvida.Digital.Beneficiary.Admin.Api;
using Microsoft.Extensions.Configuration;
using Hapvida.Digital.Beneficiary.Admin.AzureAppConfig.Services;
using Microsoft.Extensions.DependencyInjection;
using Hapvida.Digital.Beneficiary.Admin.Domain.Contracts.v1;

public static class Bootstrapper
{
    //TODO Enable if need to use redis
    //public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
    //{
    //    var connectionString = configuration.GetValue<string>("Core:Cache:ConnectionString");
    //    var instanceName = configuration.GetValue<string>("Core:Cache:InstanceName");

    //    ArgumentNullException.ThrowIfNull(connectionString);
    //    ArgumentNullException.ThrowIfNull(instanceName);

    //    return services.AddStackExchangeRedisCache(op =>
    //    {
    //        op.Configuration = connectionString;
    //        op.InstanceName = instanceName;
    //    });
    //}
    public static IServiceCollection AddApplicationRepository(this IServiceCollection services)
    {

        services.AddScoped<IFeatureFlagService, FeatureFlagService>();
        return services;
    }

}