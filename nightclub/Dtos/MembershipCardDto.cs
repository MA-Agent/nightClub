namespace nightclub.Dtos
{
    public class MembershipCardDto
    {
        public int Id { get; set; }
        public string UniqueIdentifier { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsBlacklisted { get; set; }
        public int MemberId { get; set; }
    }
}
