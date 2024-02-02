using Microsoft.FeatureManagement;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hapvida.Digital.Beneficiary.Admin.Domain.Contracts.v1;

namespace Hapvida.Digital.Beneficiary.Admin.AzureAppConfig.Services
{
    public class FeatureFlagService: IFeatureFlagService
    {
        private readonly IFeatureManager _featureManager;

        public FeatureFlagService(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<IEnumerable<string>> GetFeatureNamesAsync()
        {
            var featureNames = new List<string>();

            await foreach (var feature in _featureManager.GetFeatureNamesAsync())
            {
                featureNames.Add(feature);
            }

            return featureNames;
        }

        public async Task<bool> IsEnabledAsync(string featureName)
        {
            return await _featureManager.IsEnabledAsync(featureName);
        }
    }
}