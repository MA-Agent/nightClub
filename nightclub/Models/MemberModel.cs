using AutoMapper;
using nightclub.Dtos;
using nightclub.Entities;
using nightclub.Interfaces;

namespace nightclub.Models
{
    public class MemberModel
    {
        #region Fields
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public MemberModel(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }
        public MemberModel()
        {
        }
        #endregion


        #region Methods
        public async Task<MemberDto> createMember(MemberDto memberDto)
        {
            if (!IsEmailOrPhoneNumberProvided(memberDto))
            {
                throw new ArgumentException("Either Email or PhoneNumber must be provided");
            }
            if (!AreIdentityCardsNotExpired(memberDto.IdentityCards))
            {
                throw new ArgumentException("Age Must be over 18");
            }
            Member member = new Member(memberDto, _mapper);
            var result = await _memberService.createMember(member);
            return result;
        }

        public async Task<List<MemberDto>> getAllMembers()
        {
            
            var result = await _memberService.getAllMembers();
            return result;
        }

        public async Task<MemberDto> blackListMember(int id)
        {

            var result = await _memberService.blackListMember(id);
            return result;
        }

        public async Task<MemberDto> updateMember(int id, MemberDto memberDto)
        {
            if (!IsEmailOrPhoneNumberProvided(memberDto))
            {
                throw new ArgumentException("Either Email or PhoneNumber must be provided");
            }
            if (!AreIdentityCardsNotExpired(memberDto.IdentityCards))
            {
                throw new ArgumentException("Age Must be over 18");
            }

            Member member = new Member(memberDto, _mapper);

            var result = await _memberService.updateMember(id, member);
            return result;
        }

        public bool IsEmailOrPhoneNumberProvided(MemberDto memberdto)
        {
            return !string.IsNullOrEmpty(memberdto.Email) || !string.IsNullOrEmpty(memberdto.PhoneNumber);
        }

        public bool IsAgeOver18(IdentityCardDto identityCard)
        {
            var age = DateTime.Today.Year - identityCard.BirthDate.Year;
            if (identityCard.BirthDate.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age >= 18;
        }

        public bool AreIdentityCardsNotExpired(List<IdentityCardDto> identityCards)
        {
            foreach (var identityCard in identityCards.Where(ic => ic.ExpiryDate > DateTime.Today))
            {
                if (!IsAgeOver18(identityCard))
                {
                    return false;
                }
            }

            return true;
        }


        #endregion
    }
}
