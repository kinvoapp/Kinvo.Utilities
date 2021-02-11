using FluentAssertions;
using Xunit;

namespace Kinvo.Utilities.Test.Validations
{
    public class EmailValidationTest
    {
        [Theory]
        [InlineData("kinvo@vini.rocks", true)]
        [InlineData("kinvo@email.com", true)]
        [InlineData("kinvo.teste@email.com", true)]
        [InlineData("kinvo@email.com.br", true)]
        [InlineData("kinvo@email", false)]
        [InlineData("sometext.com", false)]
        [InlineData("_@email.com", true)]
        public void ShouldValidateCorrectly(string email, bool result)
        {
            var isValid = Utilities.Validations.Validate.IsValidEmail(email);
            result.Should().Be(isValid);
        }
    }
}
