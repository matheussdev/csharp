using System.Collections.Generic;

namespace Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetAll
{

    public sealed record GetAllQueryResponse
    {
        public IReadOnlyCollection<GetAllQueryResponseDetail>? FeatureFlags { get; init; }
    }
}