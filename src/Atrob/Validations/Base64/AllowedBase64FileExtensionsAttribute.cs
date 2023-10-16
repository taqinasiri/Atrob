using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Base64;

/// <summary>
/// Checks that the `ContentType` of the imported file is one of the allowed `ContentTypes`
/// </summary>
public class AllowedBase64FileExtensionsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Allowed file Content types
    /// </summary>
    public string[] AllowedContentTypes { get; set; }

    /// <summary>
    /// Checks that the `ContentType` of the imported file is one of the allowed `ContentTypes`
    /// </summary>
    /// <param name="isExtension">If you want to enter the file extension instead of the content type</param>
    /// <param name="allowedContentTypes">Allowed content types (if you set isExtension to true, you can enter file extensions with dot and without dot)</param>
    /// <exception cref="ArgumentNullException">If no allowedContentTypes is entered</exception>
    public AllowedBase64FileExtensionsAttribute(bool isExtension = true,params string[] allowedContentTypes) : base(ValidationErrorMessages.AllowedBase64FileExtensionsErrorMessage)
    {
        if(allowedContentTypes is null || allowedContentTypes.Length == 1)
            throw new ArgumentNullException(nameof(allowedContentTypes));
        if(isExtension)
        {
            AllowedContentTypes = new string[allowedContentTypes.Length];
            for(int i = 0; i < allowedContentTypes.Length; i++)
            {
                var extension = allowedContentTypes[i].StartsWith(".") ? allowedContentTypes[i] : $".{allowedContentTypes[i]}";
                AllowedContentTypes[i] = extension.GetMimeType() ?? string.Empty;
            }
        }
        else
            AllowedContentTypes = allowedContentTypes;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var base64 = value as string ?? string.Empty;
        if(string.IsNullOrEmpty(base64))
            return true;
        var ex = base64.RemoveBase64Header().GetBase64Extension();
        return AllowedContentTypes.Contains(ex);
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,
            string.Join(" , ",AllowedContentTypes.Select(a => a.GetExtension()).ToArray()));
}