using AutoMapper;
using Hapvida.Digital.Beneficiary.Admin.Domain.Entities.v1;

namespace Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.v1.FeatureFlags.GetAll
{

    public sealed class GetAllQueryProfile : Profile
    {
        public GetAllQueryProfile()
        {
            CreateMap<FeatureFlag, GetAllQueryResponseDetail>(MemberList.None);
        }
    }
}