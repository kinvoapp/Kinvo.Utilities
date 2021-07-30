using Kinvo.Utilities.Extensions;
using System.IO;
using Xunit;

namespace Kinvo.Utilities.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("my-custom-string")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam augue odio, sollicitudin et semper sed, consequat in tortor. Duis eget cursus leo. In euismod consequat ligula eu condimentum. Donec vel sapien in metus semper interdum nec vel sem. Proin lectus libero, porta eu nibh vitae, tristique efficitur nunc. Nunc dignissim vitae justo eu hendrerit. Etiam malesuada porttitor rutrum. Cras metus urna, cursus eu diam vel, pulvinar tristique neque. Nulla vitae sagittis sem, ac elementum lectus. Morbi tristique nunc eu mauris tempor, hendrerit fermentum purus semper. Integer malesuada mattis urna, ac maximus metus. Proin fringilla molestie nunc eu euismod. Praesent nisi enim, ornare in est sed, dignissim tincidunt arcu. Fusce nec lacus vitae urna auctor posuere. Etiam ut facilisis mi.")]
        public void ShouldGenerateCorrectStream(string input)
        {
            var resultStream = input.ToStream();
            using (var stream = new MemoryStream())
            {
                stream.Position = 0;
                using (var reader = new StreamReader(resultStream))
                {
                    var myString = reader.ReadToEnd();
                    input.Equals(myString);
                }
            }
        }
    }
}
