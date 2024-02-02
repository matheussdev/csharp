using System;
using Hapvida.Core.Domain.Contracts;
namespace Hapvida.Digital.Beneficiary.Admin.Domain.Entities.v1
{
    public class FeatureFlag
    {

        public string? Flag { get; set; }

        public bool? Enabled { get; set; }
    }
}