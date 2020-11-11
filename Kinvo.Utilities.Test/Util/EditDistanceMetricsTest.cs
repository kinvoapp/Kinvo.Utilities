using FluentAssertions;
using Kinvo.Utilities.Util;
using Xunit;

namespace Kinvo.Utilities.Test.Util
{
    public class EditDistanceMetricsTest
    {
        [Theory]
        [InlineData("ant", "aunt", 1)]
        [InlineData("fast", "cats", 3)]
        [InlineData("Elemar", "Vilmar", 3)]
        [InlineData("kitten", "sitting", 3)]
        public void Levenshtein_ShouldReturnCorrectEditDistance(string s1, string s2, int editDistance)
        {
            editDistance.Should().Be(EditDistanceMetrics.LevenshteinEditDistanceOptimized(s1, s2));
        }
    }
}
