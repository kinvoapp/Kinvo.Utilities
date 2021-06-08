using FluentAssertions;
using Kinvo.Utilities.Builders;
using Xunit;

namespace Kinvo.Utilities.Test.Builders
{
    public class EqualsBuilderTest
    {

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        public void ShouldCalculateCorrectlyIntegerComparison(int firstArg, int secondArg, bool result)
        {
            var response = new EqualsBuilder().
                                        Append(firstArg, secondArg).
                                        IsEquals();
            result.Should().Be(response);
        }

        [Theory]
        [InlineData(new int[]{1, 2, 3, 4, 5, 6}, new  int[]{1,2,3,4,5,6}, true)]
        [InlineData(new int[]{}, new  int[]{}, true)]
        [InlineData(new int[]{1, 2, 3, 4, 5, 6}, new int[]{ 1,2,3,4,5}, false)]
        [InlineData(null, new int[] { 1,2,3,4,5}, false)]
        public void ShouldCalculateCorrectlyArrayComparison(int[] firstArg, int[] secondArg, bool result)
        {
            var response = new EqualsBuilder().
                                Append(firstArg, secondArg).
                                IsEquals();
            result.Should().Be(response);
        }
    }
}
