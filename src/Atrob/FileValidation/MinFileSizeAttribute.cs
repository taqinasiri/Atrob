using System.Globalization;

namespace Atrob.FileValidation;

/// <summary>
/// Checks the minimum size that a file can have
/// </summary>
public class MinFileSizeAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// minimum file size in bytes
    /// </summary>
    public long MinFileSize { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MinFileSizeAttribute"/> class.
    /// </summary>
    /// <param name="minFileSize">minimum file size in megabyte</param>
    public MinFileSizeAttribute(double minFileSize) : base(ErrorMessages.MinFileSizeErrorMessage)
        => MinFileSize = (long)(minFileSize * 1024 * 1024);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return (file is not null && file.Length < MinFileSize) ? false : true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-minFileSize", FormatErrorMessage(context.ModelMetadata.DisplayName));
        context.MergeAttribute("data-val-minsize", MinFileSize.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MinFileSize / 1024 / 1024);
}

