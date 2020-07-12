using FluentAssertions;
using Kinvo.Utilities.Util;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Kinvo.Utilities.Test.Util
{
    public class TrackerTest
    {
        private static HttpClient client = new HttpClient();
        private const string CORRECT_RESPONSE = "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"delectus aut autem\",\n  \"completed\": false\n}";

        [Fact]
        public async Task ShouldTrackAsyncRequests()
        {
            var response = await Tracker<HttpResponseMessage>.TrackAsync(() =>
            {
                return client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            });

            var json = await response.Result.Content.ReadAsStringAsync();
            json.Should().Be(CORRECT_RESPONSE);
            response.Elapsed.Should().BeGreaterThan(TimeSpan.FromMilliseconds(0));
        }
    }
}
