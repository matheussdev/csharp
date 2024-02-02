using System.Threading;
using System.Threading.Tasks;


namespace Hapvida.Digital.Beneficiary.Admin.Domain.Contracts.v1;

public interface ICacheService
{
    Task SetCacheAsync(string key, string value, CancellationToken cancellationToken);
    Task<string> GetCacheAsync(string key, CancellationToken cancellationToken);

}
