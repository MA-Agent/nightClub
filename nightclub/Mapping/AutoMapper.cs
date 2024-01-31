using AutoMapper;
using nightclub.Dtos;
using nightclub.Entities;

namespace nightclub.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<IdentityCard, IdentityCardDto>();
            CreateMap<MembershipCard, MembershipCardDto>();

            CreateMap<MemberDto, Member>();
            CreateMap<IdentityCardDto, IdentityCard>();
            CreateMap<MembershipCardDto, MembershipCard>();


        }
    }

}
