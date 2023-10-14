using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.File;

/// <summary>
/// Checks that the `ContentType` of the imported file is not one of the illegal `ContentTypes`.
/// </summary>
public class NotAllowedFileExtensionsAttribute : ValidationAttributeBase
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
    public NotAllowedFileExtensionsAttribute(bool isExtension = true,params string[] notAllowedContentTypes) : base(ValidationErrorMessages.NotAllowedFileExtensionsErrorMessage)
    {
        if(notAllowedContentTypes is null || notAllowedContentTypes.Length == 1)
            throw new ArgumentNullException(nameof(notAllowedContentTypes));
        if(isExtension)
        {
            NotAllowedContentTypes = new string[notAllowedContentTypes.Length];
            for(int i = 0; i < notAllowedContentTypes.Length; i++)
            {
                var extension = notAllowedContentTypes[i].StartsWith(".") ? notAllowedContentTypes[i] : $".{notAllowedContentTypes[i]}";
                NotAllowedContentTypes[i] = extension.GetMimeType() ?? string.Empty;
            }
        }
        else
            NotAllowedContentTypes = notAllowedContentTypes;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return file is null || !NotAllowedContentTypes.Contains(file.ContentType);
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,
            string.Join(" , ",NotAllowedContentTypes.Select(a => a.GetExtension()).ToArray()));
}