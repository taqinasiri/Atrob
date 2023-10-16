using Atrob.Enums;
using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.File;

/// <summary>
/// Checks that the file size is not less than the specified value
/// </summary>
public class MinFileSizeAttribute : ValidationAttributeBase
{
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
    /// Checks that the file size is not less than the specified value
    /// </summary>
    /// <param name="minFileSize">Minimum file size allowed</param>
    /// <param name="unit">File size unit</param>
    /// <param name="unitDisplayName">File size unit to display in error message</param>
    public MinFileSizeAttribute(long minFileSize,FileSizeUnit unit,string? unitDisplayName = null) : base(ValidationErrorMessages.MinFileSizeErrorMessage)
    {
        UnitDisplayName = unitDisplayName ?? unit.GetDisplayName();
        MinFileSize = minFileSize;
        Unit = unit;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return file is null || MinFileSize.ToByte(Unit) <= file.Length;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinFileSize,UnitDisplayName);
}