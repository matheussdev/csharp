using System.Collections.Generic;
using System.Threading.Tasks;
using Hapvida.Digital.Beneficiary.Admin.Domain.Entities.v1;

namespace Hapvida.Digital.Beneficiary.Admin.Domain.Interfaces
{
    public interface IFeatureFlagService
    {
        Task<IEnumerable<FeatureFlag>> GetFeatureFlagsAsync();
    }
}