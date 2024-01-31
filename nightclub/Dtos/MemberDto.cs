using AutoMapper;
using nightclub.Entities;

namespace nightclub.Dtos
{
    public class MemberDto
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBlacklisted { get; set; }
        public List<IdentityCardDto> IdentityCards { get; set; }
        public List<MembershipCardDto> MembershipCards { get; set; }

        public MemberDto(Member member, IMapper mapper)
        {
            // Initialize all fields here
            this.Id = member.Id;
            this.Email = member.Email;
            this.PhoneNumber = member.PhoneNumber;
            this.IsBlacklisted = member.IsBlacklisted;
            this.IdentityCards = mapper.Map<List<IdentityCardDto>>(member.IdentityCards);
            this.MembershipCards = mapper.Map<List<MembershipCardDto>>(member.MembershipCards);
        }

        public MemberDto()
        {
            
        }
    }

}
