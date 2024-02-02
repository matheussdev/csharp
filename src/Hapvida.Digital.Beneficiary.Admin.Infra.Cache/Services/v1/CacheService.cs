

using Hapvida.Digital.Beneficiary.Admin.Infra.Cache.Models.v1;
using Hapvida.Digital.Beneficiary.Admin.Domain.Contracts.v1;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Hapvida.Digital.Beneficiary.Admin.Domain.Resources.v1;
namespace Hapvida.Digital.Beneficiary.Admin.Infra.Cache.Services.v1
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly CacheOptions _cacheOptions;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IDistributedCache distributedCache, CacheOptions cacheOptions, ILogger<CacheService> logger)
        {
            _distributedCache = distributedCache;
            _cacheOptions = cacheOptions;
            _logger = logger;
        }

        public async Task<string> GetCacheAsync(string key, CancellationToken cancellationToken)
        {
            try
            {
                return await _distributedCache.GetStringAsync(key, cancellationToken);
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task SetCacheAsync(string key, string value, CancellationToken cancellationToken)
        {
            try
            {
                await _distributedCache.SetStringAsync(key, value, _cacheOptions.Options, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(LogTemplate.ErrorHandler, nameof(CacheService), ex.Message);
            }
        }
    }

}