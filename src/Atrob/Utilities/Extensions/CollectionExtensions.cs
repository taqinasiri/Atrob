namespace Atrob.Utilities.Extensions;

internal static class CollectionExtensions
{
    public static IEnumerable<object> RemoveNulls(this IEnumerable<object> collection)
        => collection.Where(i => i is not null);
}