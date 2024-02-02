using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hapvida.Digital.Beneficiary.Admin.Domain.Contracts.v1
{
    public interface IFeatureFlagService
    {
        Task<IEnumerable<string>> GetFeatureNamesAsync();
        Task<bool> IsEnabledAsync(string featureName);
    }
}