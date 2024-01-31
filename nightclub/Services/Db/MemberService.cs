using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nightclub.Dtos;
using nightclub.Entities;
using nightclub.Interfaces;
using nightclub.Mapping;

namespace nightclub.Services.Db
{
    public class MemberService : IMemberService
    {
        #region Fields
        private readonly DbNightClubContext _context;
        private readonly IMapper _mapper;

        #endregion
        #region Constructor
        public MemberService(DbNightClubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        async Task<MemberDto> IMemberService.createMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return new MemberDto(member, _mapper);
        }

        async Task<List<MemberDto>> IMemberService.getAllMembers()
        {
            var dbmemberList = await _context.Members.Include(m => m.IdentityCards).Include(m => m.MembershipCards).ToListAsync();

            return _mapper.Map<List<MemberDto>>(dbmemberList);
        }

        async Task<MemberDto> IMemberService.blackListMember(int id)
        {
            var dbmember = await _context.Members.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (dbmember != null)
            {
                dbmember.IsBlacklisted = !dbmember.IsBlacklisted;
                await _context.SaveChangesAsync();
                return _mapper.Map<MemberDto>(dbmember);
            } else
            {
                throw new ArgumentException("Member not found");

            }
        }

        async Task<MemberDto> IMemberService.updateMember(int id, Member member)
        {
            var dbmember = await _context.Members.Include(m=> m.IdentityCards).Include(m=> m.MembershipCards).Where(m => m.Id == id).FirstOrDefaultAsync();
            if (dbmember != null)
            {
                dbmember.Email = member.Email;
                dbmember.PhoneNumber = member.PhoneNumber;
                dbmember.IsBlacklisted = member.IsBlacklisted;
                dbmember.IdentityCards = member.IdentityCards;
                dbmember.MembershipCards = member.MembershipCards;

                await _context.SaveChangesAsync();

                return _mapper.Map<MemberDto>(dbmember);
            }
            else
            {
                throw new ArgumentException("Member not found");
            }
        }

        #endregion
    }
}
