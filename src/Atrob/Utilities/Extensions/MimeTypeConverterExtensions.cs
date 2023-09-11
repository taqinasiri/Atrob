using Atrob.Utilities.Constants;

namespace Atrob.Utilities.Extensions;

internal static class MimeTypeConverterExtensions
{
    public static string? GetExtension(this string mimeType)
        => MimeTypes.Types.FirstOrDefault(t => t.Value == mimeType.ToLower()).Key;

    public static string? GetMimeType(this string extension) =>
        MimeTypes.Types.TryGetValue(extension, out var mimeType) ? mimeType : null;
}
