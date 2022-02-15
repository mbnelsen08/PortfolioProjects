using System.Collections.Generic;
using System.Linq;

namespace DrakkenheimEncountersBot.ZachStuff.Extensions
{
    internal static class IEnumerableExtensions
    {
        // This is what is called an Extension Method.
        // We're allowed to create static functions that get called on objects and classes
        // that already exist (that maybe we didn't even make!)
        //
        // This is also what is called a Generic Method.
        // We don't know exactly what type T is, it could be an int, an Encounter, a string, doesn't matter.
        // All we know is its gonna be an IEnumerable and I'm gonna turn it into an IReadOnlyCollection.
        public static IReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> @this)
        {
            return @this.ToList().AsReadOnly();
        }
    }
}
