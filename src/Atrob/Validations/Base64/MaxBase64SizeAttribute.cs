using Atrob.Enums;
using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Base64;

/// <summary>
/// Base64 size unit to display in error message
/// </summary>
public class MaxBase64SizeAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum Base64 size allowed
    /// </summary>
    public long MaxBase64Size { get; init; }

    /// <summary>
    /// Base64 size unit
    /// </summary>
    public FileSizeUnit Unit { get; init; }

    /// <summary>
    /// Base64 size unit to display in error message
    /// </summary>
    public string UnitDisplayName { get; set; }

    /// <summary>
    /// Checks that the Base64 size does not exceed the specified value
    /// </summary>
    /// <param name="maxBase64Size">Maximum Base64 size allowed</param>
    /// <param name="unit">Base64 size unit</param>
    /// <param name="unitDisplayName">Base64 size unit to display in error message</param>
    public MaxBase64SizeAttribute(long maxBase64Size,FileSizeUnit unit,string? unitDisplayName = null) : base(ValidationErrorMessages.MaxBase64SizeErrorMessage)
    {
        UnitDisplayName = unitDisplayName ?? unit.GetDisplayName();
        MaxBase64Size = maxBase64Size;
        Unit = unit;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        string base64 = value as string ?? string.Empty;
        if(string.IsNullOrEmpty(base64))
            return true;

        byte[] data = Convert.FromBase64String(base64);
        return MaxBase64Size.ToByte(Unit) >= data.Length;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxBase64Size,UnitDisplayName);
}