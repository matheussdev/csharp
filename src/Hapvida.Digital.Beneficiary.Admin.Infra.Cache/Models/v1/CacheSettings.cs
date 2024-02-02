namespace Hapvida.Digital.Beneficiary.Admin.Infra.Cache.Models.v1
{
    public sealed class CacheSettings
    {
        public static string SessionName => "Core:Cache";

        public string? ConnectionString { get; set; }

        public string? InstanceName { get; set; }
    }
}