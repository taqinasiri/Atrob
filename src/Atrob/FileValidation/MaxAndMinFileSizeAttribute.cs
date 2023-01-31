using System.Globalization;

namespace Atrob.FileValidation;

/// <summary>
///  Checks the maximum and minimum number size that a file can have
/// </summary>
public class MaxAndMinFileSizeAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// Maximum file size in bytes
    /// </summary>
    public double MinFileSize { get; private set; }

    /// <summary>
    /// Minimum file size in bytes
    /// </summary>
    public double MaxFileSize { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxAndMinFileSizeAttribute"/> class.
    /// </summary>
    /// <param name="maxFileSize"> Maximum file size in megabytes</param>
    /// <param name="minFileSize">Minimum file size in megabytes</param>
    /// <exception cref="ArgumentException">If the <paramref name="minFileSize"/> is greater than the <paramref name="maxFileSize"/></exception>
    public MaxAndMinFileSizeAttribute(double maxFileSize, double minFileSize) : base(ErrorMessages.MaxAndMinFileSizeErrorMessage)
    {
        if (minFileSize >= maxFileSize)
            throw new ArgumentException($"{minFileSize} cannot be less than or equal to {maxFileSize}");
        MaxFileSize = maxFileSize * 1024 * 1024;
        MinFileSize = minFileSize * 1024 * 1024;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return (file is not null && (file.Length > MaxFileSize || file.Length < MinFileSize)) ? false : true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-maxAndMinFileSize", FormatErrorMessage(context.ModelMetadata.DisplayName));
        context.MergeAttribute("data-val-maxsize", MaxFileSize.ToString());
        context.MergeAttribute("data-val-minsize", MinFileSize.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MaxFileSize / 1024 / 1024, MinFileSize / 1024 / 1024);
}

