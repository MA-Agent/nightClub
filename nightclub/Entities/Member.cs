using AutoMapper;
using nightclub.Dtos;

namespace nightclub.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBlacklisted { get; set; }
        public ICollection<IdentityCard> IdentityCards { get; set; }
        public ICollection<MembershipCard> MembershipCards { get; set; }
        // Parameterless constructor required by EF Core
        public Member()
        {
        }

        public Member(MemberDto memberDto, IMapper mapper)
        {
            // Initialize all fields here
            this.Email = memberDto.Email;
            this.PhoneNumber = memberDto.PhoneNumber;
            this.IsBlacklisted = memberDto.IsBlacklisted;
            this.IdentityCards = mapper.Map<List<IdentityCard>>(memberDto.IdentityCards);
            this.MembershipCards = mapper.Map<List<MembershipCard>>(memberDto.MembershipCards);
        }
    }
}
