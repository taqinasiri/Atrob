using Atrob.Enums;
using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.File;

/// <summary>
/// Checks if the file size is within the specified range
/// </summary>
public class RangeFileSizeAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum file size allowed
    /// </summary>
    public long MaxFileSize { get; init; }

    /// <summary>
    /// Minimum file size allowed
    /// </summary>
    public long MinFileSize { get; init; }

    /// <summary>
    /// File size unit
    /// </summary>
    public FileSizeUnit Unit { get; init; }

    /// <summary>
    /// File size unit to display in error message
    /// </summary>
    public string UnitDisplayName { get; set; }

    /// <summary>
    /// Checks if the file size is within the specified range
    /// </summary>
    /// <param name="maxFileSize">Maximum file size allowed</param>
    /// <param name="minFileSize">Minimum file size allowed</param>
    /// <param name="unit">File size unit</param>
    /// <param name="unitDisplayName">File size unit to display in error message</param>
    /// <exception cref="ArgumentException">If minfilesize is greater than maxfilesize</exception>
    public RangeFileSizeAttribute(long maxFileSize,long minFileSize,FileSizeUnit unit,string? unitDisplayName = null) : base(ValidationErrorMessages.RangeFileSizeErrorMessage)
    {
        if(minFileSize > maxFileSize)
            throw new ArgumentException($"{minFileSize} cannot be less than or equal to {maxFileSize}");
        UnitDisplayName = unitDisplayName ?? unit.GetDisplayName();
        MaxFileSize = maxFileSize;
        MinFileSize = minFileSize;
        Unit = unit;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return file is null || (MaxFileSize.ToByte(Unit) >= file.Length && MinFileSize.ToByte(Unit) <= file.Length);
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinFileSize,MaxFileSize,UnitDisplayName);
}