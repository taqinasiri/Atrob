using System.Globalization;

namespace Atrob.FileValidation;

/// <summary>
/// Checks the maximum size that a file can have
/// </summary>
public class MaxFileSizeAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// Maximum file size in bytes
    /// </summary>
    public long MaxFileSize { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxFileSizeAttribute"/> class.
    /// </summary>
    /// <param name="maxFileSize">Maximum file size in megabyte</param>
    public MaxFileSizeAttribute(double maxFileSize) : base(ErrorMessages.MaxFileSizeErrorMessage)
        => MaxFileSize = (long)(maxFileSize * 1024 * 1024);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        if (file is not null && file.Length > MaxFileSize) return false;
        return true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-maxFileSize", FormatErrorMessage(context.ModelMetadata.DisplayName));
        context.MergeAttribute("data-val-maxsize", MaxFileSize.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MaxFileSize / 1024 / 1024);
}

