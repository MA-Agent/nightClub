using System.ComponentModel.DataAnnotations;

namespace nightclub.Dtos
{
    public class IdentityCardDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalNumber { get; set; }
        public DateTime ValidityDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [RegularExpression(@"^\d{3}\.\d{2}\.\d{2}-\d{3}-\d{2}$", ErrorMessage = "CardNumber must be in the format 'xxx.xx.xx-xxx-xx'")]
        public string CardNumber { get; set; }
        public int MemberId { get; set; }
    }
}
