namespace Hapvida.Digital.Beneficiary.Admin.Api;
using Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetAll;
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


        return services;
    }

}