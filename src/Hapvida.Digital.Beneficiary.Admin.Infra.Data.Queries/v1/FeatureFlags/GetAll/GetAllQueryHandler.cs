using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Hapvida.Core.Domain.Handlers;
using Hapvida.Core.Domain.Models;
using Hapvida.Digital.Beneficiary.Admin.AzureAppConfig.Services;
using Hapvida.Digital.Beneficiary.Admin.Domain.Entities.v1;
using System.Collections.Generic;
using System.Linq;

namespace Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetAll
{
    public sealed class GetAllQueryHandler : QueryHandler<GetAllQuery>
    {
        private readonly IMapper _mapper;
        private readonly FeatureManagerService _featureManagerService;

        public GetAllQueryHandler(IMapper mapper, FeatureManagerService featureManagerService)
        {
            _mapper = mapper;
            _featureManagerService = featureManagerService;
        }

        public override async Task<Response> Handle(GetAllQuery query, CancellationToken cancellationToken)
        {
            var featureNames = await _featureManagerService.GetFeatureNamesAsync();
            var features = new List<FeatureFlag>();

            foreach (var featureName in featureNames)
            {
                var enabled = await _featureManagerService.IsEnabledAsync(featureName);
                features.Add(new FeatureFlag { Flag = featureName, Enabled = enabled });
            }

            var responseDetails = _mapper.Map<List<FeatureFlag>, List<GetAllQueryResponseDetail>>(features);
            var response = new GetAllQueryResponse { FeatureFlags = responseDetails };

            return new Response { Content = response };
        }
    }
}