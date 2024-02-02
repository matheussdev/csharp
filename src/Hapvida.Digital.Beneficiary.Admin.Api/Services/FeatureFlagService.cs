using Hapvida.Digital.Beneficiary.Admin.Domain.Entities.v1;
using Hapvida.Digital.Beneficiary.Admin.Domain.Interfaces;
using Microsoft.FeatureManagement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hapvida.Digital.Beneficiary.Admin.Api.Services
{
    public class FeatureFlagService : IFeatureFlagService
    {
        private readonly IFeatureManager _featureManager;
        public FeatureFlagService(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<IEnumerable<FeatureFlag>> GetFeatureFlagsAsync()
        {
            var featureFlags = new List<FeatureFlag>();

            await foreach (var feature in _featureManager.GetFeatureNamesAsync())
            {
                var featureFlag = new FeatureFlag
                {
                    Flag = feature,
                    Enabled = await _featureManager.IsEnabledAsync(feature)
                };

                featureFlags.Add(featureFlag);
            }

            return featureFlags;
        }
    }
}