using System.Globalization;

namespace Atrob.FileValidation;

/// <summary>
/// Checks what types the file can contain
/// </summary>
public class AllowedFileExtensionsAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// An array of content types allowed for the file
    /// </summary>
    public string[] AllowedContentTypes { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AllowedFileExtensionsAttribute"/> class.
    /// </summary>
    /// <param name="allowedContentTypes">An array of content types allowed for the file</param>
    public AllowedFileExtensionsAttribute(params string[] allowedContentTypes) : base(ErrorMessages.AllowedFileExtensionsErrorMessage)
        => AllowedContentTypes = allowedContentTypes;

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        if (file is not null && !AllowedContentTypes.Contains(file.ContentType)) return false;
        return true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-allowedExtensions", FormatErrorMessage(context.ModelMetadata.DisplayName));
        context.MergeAttribute("data-val-whitelistextensions", string.Join(',', AllowedContentTypes));
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name,
            string.Join(" / ", AllowedContentTypes.Select(a => a.GetExtensionFromMimetype()).ToArray()));
}



