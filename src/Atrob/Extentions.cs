namespace Atrob;

/// <summary>
/// A static class containing Atrob extension methods
/// </summary>
public static class Extentions
{
    /// <summary>
    /// Adds required attributes for client side validations
    /// </summary>
    /// <param name="key">Attribute Key</param>
    /// <param name="value">Attribute Value</param>
    public static void MergeAttribute(this ClientModelValidationContext context, string key, string value)
    {
        if (!context.Attributes.ContainsKey(key))
            context.Attributes.Add(key, value);
    }

    /// <summary>
    /// The file extension is obtained from its contentType
    /// </summary>
    /// <param name="mimeType">ContentType</param>
    /// <returns>The extension of that content type</returns>
    public static string GetExtensionFromMimetype(this string mimeType)
        => MimeTypes.MimeTypeMap.GetExtension(mimeType);
}
