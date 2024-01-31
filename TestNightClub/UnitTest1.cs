using nightclub.Dtos;
using nightclub.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestNightClub
{
    [TestFixture]
    public class MemberModelTests
    {
        private MemberModel _memberModel;

        [SetUp]
        public void SetUp()
        {
            _memberModel = new MemberModel();
        }

        [Test]
        public void IsAgeOver18_ShouldReturnTrue_WhenAgeIsOver18()
        {
            // Arrange
            var identityCard = new IdentityCardDto
            {
                BirthDate = new DateTime(2000, 1, 1)
            };

            // Act
            var result = _memberModel.IsAgeOver18(identityCard);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsAgeOver18_ShouldReturnFalse_WhenAgeIsUnder18()
        {
            // Arrange
            var identityCard = new IdentityCardDto
            {
                BirthDate = DateTime.Today.AddYears(-17)
            };

            // Act
            var result = _memberModel.IsAgeOver18(identityCard);

            // Assert
            Assert.That(result, Is.False);
        }
    }

}