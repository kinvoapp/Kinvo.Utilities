using System.Linq;

namespace Kinvo.Utilities.Extensions
{
    public static class ObjectExtensions
    {
        public static void CopyPropertiesTo<TSource, TDest>(this TSource source, TDest destination)
        {
            var sourceProperties = typeof(TSource).GetProperties()
                .Where(sourceProperty => sourceProperty.CanRead)
                .ToList();
            var destinationProperties = typeof(TDest).GetProperties()
                .Where(destinationProperty => destinationProperty.CanWrite)
                .ToList();

            foreach (var sourceProp in sourceProperties)
            {
                var matchingDestinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProp.Name);

                if (matchingDestinationProperty != null)
                    matchingDestinationProperty.SetValue(destination, sourceProp.GetValue(source, null), null);
            }
        }
    }
}
