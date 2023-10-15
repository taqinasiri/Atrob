using Atrob.Enums;
using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Base64;

/// <summary>
/// Checks if the Base64 size is within the specified range
/// </summary>
public class RangeBase64SizeAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum Base64 size allowed
    /// </summary>
    public long MaxBase64Size { get; init; }

    /// <summary>
    /// Minimum Base64 size allowed
    /// </summary>
    public long MinBase64Size { get; init; }

    /// <summary>
    /// Base64 size unit
    /// </summary>
    public FileSizeUnit Unit { get; init; }

    /// <summary>
    /// Base64 size unit to display in error message
    /// </summary>
    public string UnitDisplayName { get; set; }

    /// <summary>
    /// Checks if the Base64 size is within the specified range
    /// </summary>
    /// <param name="maxBase64Size">Maximum Base64 size allowed</param>
    /// <param name="minBase64Size">Minimum Base64 size allowed</param>
    /// <param name="unit">Base64 size unit</param>
    /// <param name="unitDisplayName">Base64 size unit to display in error message</param>
    /// <exception cref="ArgumentException">If minBase64size is greater than maxBase64size</exception>
    public RangeBase64SizeAttribute(long maxBase64Size,long minBase64Size,FileSizeUnit unit,string? unitDisplayName = null) : base(ValidationErrorMessages.RangeBase64SizeErrorMessage)
    {
        if(minBase64Size > maxBase64Size)
            throw new ArgumentException($"{minBase64Size} cannot be less than or equal to {maxBase64Size}");
        UnitDisplayName = unitDisplayName ?? unit.GetDisplayName();
        MaxBase64Size = maxBase64Size;
        MinBase64Size = minBase64Size;
        Unit = unit;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        string base64 = value as string ?? string.Empty;
        if(string.IsNullOrEmpty(base64))
            return true;

        byte[] data = Convert.FromBase64String(base64);
        return MaxBase64Size.ToByte(Unit) >= data.Length && MinBase64Size.ToByte(Unit) <= data.Length;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinBase64Size,MaxBase64Size,UnitDisplayName);
}