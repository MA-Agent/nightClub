namespace nightclub.Entities
{
    public class IdentityCard
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalNumber { get; set; }
        public DateTime ValidityDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardNumber { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
