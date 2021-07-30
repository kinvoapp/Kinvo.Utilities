using FluentAssertions;
using Kinvo.Utilities.Util;
using Xunit;

namespace Kinvo.Utilities.Test.Util
{
    public class RegexUtilTest
    {
        [Theory]
        [InlineData("<span><a href=\"#message\">", true)]
        [InlineData("<span", false)]
        [InlineData("<span>My Username</span>", true)]
        [InlineData("<html><body><script>alert('Hello, world!');</ script ></ body ></    html >", true)]
        public void HTMLInjection_ShouldAnalizeCorrectly(string input, bool expected)
        {
            RegexUtil.MatchHTMLInjection(input).Should().Be(expected);
        }
    }
}
