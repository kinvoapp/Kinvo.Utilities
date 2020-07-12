using FluentAssertions;
using Kinvo.Utilities.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Kinvo.Utilities.Test.Extensions
{
    public class ListExtensionsTest
    {
        [Theory]
        [MemberData(nameof(ListWithItemsData))]
        public void IsNullOrEmpty_ShouldReturnFalse_WhenListHasAnyItems(List<List<object>> testData)
        {
            foreach (var testItem in testData)
                testItem.IsNullOrEmpty().Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(EmptyListData))]
        public void IsNullOrEmpty_ShouldReturnTrue_WhenListIsNullOrEmpty(List<List<object>> testData)
        {
            foreach (var testItem in testData)
                testItem.IsNullOrEmpty().Should().BeTrue();
        }

        public static IEnumerable<object[]> ListWithItemsData()
        {
            var testData = new List<List<object>>
            {
                new List<object> { 1, 2, 3 },
                new List<object> { "test1", "test2", "test3" },
            };

            yield return new object[] { testData };
        }

        public static IEnumerable<object[]> EmptyListData()
        {
            var testData = new List<List<object>>
            {
                new List<object> {  },
                null
            };

            yield return new object[] { testData };
        }
    }
}
