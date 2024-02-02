using System.Text.Json;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Hapvida.Core.Domain.Handlers;
using Hapvida.Core.Domain.Models;
using Hapvida.Digital.Beneficiary.Admin.AzureAppConfig.Services;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Hapvida.Booking.Infra.Data.Queries.Queries.v1.FeatureFlags.GetFlags;

namespace Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetFlags
{
    public sealed class GetFlagsQueryHandler : QueryHandler<GetFlagsQuery>
    {
        private readonly IMapper _mapper;
        private readonly FeatureFlagService _featureManagerService;

        public GetFlagsQueryHandler(IMapper mapper, FeatureFlagService featureManagerService)
        {
            _mapper = mapper;
            _featureManagerService = featureManagerService;
        }

        public override async Task<Response> Handle(GetFlagsQuery query, CancellationToken cancellationToken)
        {
            var featureNames = await _featureManagerService.GetFeatureNamesAsync();
            var features = new List<GetFlagsQueryResponse>();

            foreach (var featureName in featureNames)
            {
                var enabled = await _featureManagerService.IsEnabledAsync(featureName);
                features.Add(new GetFlagsQueryResponse { Flag = featureName, Enabled = enabled });
            }

            var content = _mapper.Map<List<GetFlagsQueryResponse>>(features);

            return new Response { Content = content.OrderBy(x => x.Flag) };
        }
    }
}