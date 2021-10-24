using FluentAssertions;
using Xunit;

namespace Kinvo.Utilities.Test.Validations
{
    public class CNPJValidationTest
    {
        [Theory]
        [InlineData("27.883.844/0001-84", true)]
        [InlineData("29.750.279/0001-02", true)]
        [InlineData("88.408.631/0001-95", true)]
        [InlineData("01.234.567/8910-11", false)]
        [InlineData("1.234.567/8910-11", false)]
        [InlineData("234.567/8910-11", false)]
        public void ShouldValidateCorrectly(string document, bool result)
        {
            var isValid = Utilities.Validations.Validate.IsValidCNPJ(document);
            result.Should().Be(isValid);
        }
    }
}
