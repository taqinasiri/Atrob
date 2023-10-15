using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Base64;

/// <summary>
/// Checks that the `ContentType` of the imported file is not one of the illegal `ContentTypes`.
/// </summary>
public class NotAllowedBase64FileExtensionsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Not Allowed file Content types
    /// </summary>
    public string[] NotAllowedContentTypes { get; set; }

    /// <summary>
    /// Checks that the `ContentType` of the imported file is not one of the illegal `ContentTypes`.
    /// </summary>
    /// <param name="isExtension">If you want to enter the file extension instead of the content type</param>
    /// <param name="notAllowedContentTypes">Not allowed content types (if you set isExtension to true, you can enter file extensions with dot and without dot)</param>
    /// <exception cref="ArgumentNullException">If no Content type is entered</exception>
    public NotAllowedBase64FileExtensionsAttribute(bool isExtension = true,params string[] allowedContentTypes) : base(ValidationErrorMessages.NotAllowedBase64FileExtensionsErrorMessage)
    {
        if(allowedContentTypes is null || allowedContentTypes.Length == 1)
            throw new ArgumentNullException(nameof(allowedContentTypes));
        if(isExtension)
        {
            NotAllowedContentTypes = new string[allowedContentTypes.Length];
            for(int i = 0; i < allowedContentTypes.Length; i++)
            {
                var extension = allowedContentTypes[i].StartsWith(".") ? allowedContentTypes[i] : $".{allowedContentTypes[i]}";
                NotAllowedContentTypes[i] = extension.GetMimeType() ?? string.Empty;
            }
        }
        else
            NotAllowedContentTypes = allowedContentTypes;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var base64 = value as string ?? string.Empty;
        if(string.IsNullOrEmpty(base64))
            return true;
        var ex = base64.RemoveBase64Header().GetBase64Extension();
        return !NotAllowedContentTypes.Contains(ex);
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,
            string.Join(" , ",NotAllowedContentTypes.Select(a => a.GetExtension()).ToArray()));
}