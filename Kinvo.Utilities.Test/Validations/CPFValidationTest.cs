using FluentAssertions;
using Xunit;

namespace Kinvo.Utilities.Test.Validations
{
    public class CPFValidationTest
    {
        [Theory]
        [InlineData("123.456.789-12", false)]
        [InlineData("529.982.247-25", true)]
        [InlineData("777.777.777-77", false)]
        [InlineData("000.000.000-00", false)]
        [InlineData("151.476.070-30", true)]
        [InlineData("151.476.07030", true)]
        [InlineData("151476070-30", true)]
        public void ShouldValidateCorrectly(string document, bool result)
        {
            var isValid = Utilities.Validations.Validate.IsValidCPF(document);
            result.Should().Be(isValid);
        }
    }
}
