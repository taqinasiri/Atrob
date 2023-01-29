using System.Globalization;

namespace Atrob.FileValidation;

/// <summary>
/// Checks what types the file cannot have
/// </summary>
public class NotAllowedFileExtensionsAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    ///  An array of content types not allowed for the file
    /// </summary>
    public string[] NotAllowedContentTypes { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AllowedFileExtensionsAttribute"/> class.
    /// </summary>
    /// <param name="notAllowedContentTypes">An array of content types not allowed for the file</param>
    public NotAllowedFileExtensionsAttribute(params string[] notAllowedContentTypes) : base(ErrorMessages.NotAllowedFileExtensionsErrorMessage)
        => NotAllowedContentTypes = notAllowedContentTypes;

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        if (file is not null && NotAllowedContentTypes.Contains(file.ContentType)) return false;
        return true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-notAllowedExtensions", FormatErrorMessage(context.ModelMetadata.DisplayName));
        context.MergeAttribute("data-val-blacklistextensions", string.Join(',', NotAllowedContentTypes));
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name,
            string.Join(" / ", NotAllowedContentTypes.Select(a => a.GetExtensionFromMimetype()).ToArray()));
}



