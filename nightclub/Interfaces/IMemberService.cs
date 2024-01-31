using nightclub.Dtos;
using nightclub.Entities;

namespace nightclub.Interfaces
{
    public interface IMemberService
    {
        Task<MemberDto> createMember(Member member);
        Task<List<MemberDto>> getAllMembers();
        Task<MemberDto> blackListMember(int id);

        Task<MemberDto> updateMember(int id, Member member);

    }
}
