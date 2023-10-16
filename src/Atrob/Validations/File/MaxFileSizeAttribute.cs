using Atrob.Enums;
using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.File;

/// <summary>
/// Checks that the file size does not exceed the specified value
/// </summary>
public class MaxFileSizeAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum file size allowed
    /// </summary>
    public long MaxFileSize { get; init; }

    /// <summary>
    /// File size unit
    /// </summary>
    public FileSizeUnit Unit { get; init; }

    /// <summary>
    /// File size unit to display in error message
    /// </summary>
    public string UnitDisplayName { get; set; }

    /// <summary>
    /// Checks that the file size does not exceed the specified value
    /// </summary>
    /// <param name="maxFileSize">Maximum file size allowed</param>
    /// <param name="unit">File size unit</param>
    /// <param name="unitDisplayName">File size unit to display in error message</param>
    public MaxFileSizeAttribute(long maxFileSize,FileSizeUnit unit,string? unitDisplayName = null) : base(ValidationErrorMessages.MaxFileSizeErrorMessage)
    {
        UnitDisplayName = unitDisplayName ?? unit.GetDisplayName();
        MaxFileSize = maxFileSize;
        Unit = unit;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return file is null || MaxFileSize.ToByte(Unit) >= file.Length;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxFileSize,UnitDisplayName);
}