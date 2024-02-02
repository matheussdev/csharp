using System;

namespace Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetAll
{
    public record GetAllQueryResponseDetail
    {
        public string? Flag { get; set; }
        public bool Enabled { get; set; }
    }
}