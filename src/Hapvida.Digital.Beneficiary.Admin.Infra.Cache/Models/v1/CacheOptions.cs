using Microsoft.Extensions.Caching.Distributed;

namespace Hapvida.Digital.Beneficiary.Admin.Infra.Cache.Models.v1
{
    public class CacheOptions
    {
        public CacheOptions(int minutesToExpireToken)
        {
            SetOptions(minutesToExpireToken);
        }

        public static string SessionName => "Core:Cache:MinutesToExpireToken";

        public DistributedCacheEntryOptions? Options { get; private set; }

        public void SetOptions(int minutesToExpireToken)
        {
            var options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromMinutes(minutesToExpireToken));
            Options = options;
        }
    }

}