using Kinvo.Utilities.Extensions;
using Xunit;
using FluentAssertions;
using System;

namespace Kinvo.Utilities.Test
{
    public class ObjectExtensions
    {
        [Theory]
        [InlineData(1)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void ShouldCopyAvailableProps(int idValue)
        {
            var dest = new Dest();
            var src = new Src() { Id = idValue };
            src.CopyPropertiesTo(dest);

            dest.Id.Should().Be(idValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void ShouldntCopyUnavailableProps(int idValue)
        {
            var dest = new Dest();
            var src = new Src() { DifferentId = idValue };
            src.CopyPropertiesTo(dest);

            dest.DifferentId.Should().Be(null);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(Int32.MaxValue)]
        [InlineData(Int32.MinValue)]
        public void ShouldntCopyToUnwrittableProps(int idValue)
        {
            var dest = new Dest();
            var src = new Src() { UnwritableIdOnDest = idValue };
            src.CopyPropertiesTo(dest);

            src.UnwritableIdOnDest.Should().Be(idValue);
            dest.UnwritableIdOnDest.Should().Be(null);
        }
        
        [Fact]
        public void EmptyClassShouldntThrowError()
        {
            var empty = new Empty();
            var src = new Src() { Id = 1 };
            Action copyToEmpty = () => src.CopyPropertiesTo(empty);
            Action copyFromEmpty = () => empty.CopyPropertiesTo(src);
            copyToEmpty.Should().NotThrow();
            copyFromEmpty.Should().NotThrow();
        }
    }

    public class Src
    {
        public int Id { get; set; }
        private int differentId;
        public int DifferentId { set { this.differentId = value; } }
        public int UnwritableIdOnDest { get; set; }
    }

    public class Dest
    {
        public int Id { get; private set; }
        public int? DifferentId { get; private set; }
        public int? UnwritableIdOnDest { get; }
    }
    
    public class Empty
    {
    }
}
