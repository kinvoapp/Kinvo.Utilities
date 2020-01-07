using System;
using System.Web;

namespace Kinvo.Utilities.Extensions
{
    public static class HttpExtensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
            httpValueCollection.Remove(name);
            httpValueCollection.Add(name, value);

            var uriBuilder = new UriBuilder(uri);
            uriBuilder.Query = httpValueCollection.ToString();

            return uriBuilder.Uri;
        }
    }
}
