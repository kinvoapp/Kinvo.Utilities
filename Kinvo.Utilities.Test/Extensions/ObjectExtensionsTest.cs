using FluentAssertions;
using Kinvo.Utilities.Extensions;
using System;
using Xunit;

namespace Kinvo.Utilities.Test.Extensions
{
    public class ObjectExtensionsTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void CopyPropertiesTo_ShouldCopyProps_WhenAvailable(int idValue)
        {
            var dest = new DestinationDTO();
            var src = new SourceDTO() { Id = idValue };
            src.CopyPropertiesTo(dest);

            dest.Id.Should().Be(idValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void CopyPropertiesTo_ShouldntCopyProps_WhenUnavailable(int idValue)
        {
            var dest = new DestinationDTO();
            var src = new SourceDTO() { DifferentId = idValue };
            src.CopyPropertiesTo(dest);

            dest.DifferentId.Should().Be(null);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void CopyPropertiesTo_ShouldntCopyProps_WhenUnwrittable(int idValue)
        {
            var dest = new DestinationDTO();
            var src = new SourceDTO() { UnwritableIdOnDest = idValue };
            src.CopyPropertiesTo(dest);

            src.UnwritableIdOnDest.Should().Be(idValue);
            dest.UnwritableIdOnDest.Should().Be(null);
        }

        [Fact]
        public void CopyPropertiesTo_ShouldntThrowError_WhenEmptyClass()
        {
            var empty = new EmptyDTO();
            var src = new SourceDTO() { Id = 1 };
            Action copyToEmpty = () => src.CopyPropertiesTo(empty);
            Action copyFromEmpty = () => empty.CopyPropertiesTo(src);
            copyToEmpty.Should().NotThrow();
            copyFromEmpty.Should().NotThrow();
        }

        [Fact]
        public void ToDynamic_ShouldMaintainExistingProps_WhenObjectIsFilled()
        {
            var sourceTest = new SourceDTO
            {
                Id = 1
            };

            var dynamicSourceTest = sourceTest.ToDynamic();
            Assert.True(dynamicSourceTest != null);
            Assert.Equal(dynamicSourceTest.Id, 1);
        }
    }

    public class SourceDTO
    {
        public int Id { get; set; }
        private int differentId;
        public int DifferentId { set { this.differentId = value; } }
        public int UnwritableIdOnDest { get; set; }
    }

    public class DestinationDTO
    {
        public int Id { get; private set; }
        public int? DifferentId { get; private set; }
        public int? UnwritableIdOnDest { get; }
    }

    public class EmptyDTO
    {
    }
}
