using Atrob.Enums;
using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Base64;

/// <summary>
/// Base64 size unit to display in error message
/// </summary>
public class MinBase64SizeAttribute : ValidationAttributeBase
{
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
    /// Checks that the Base64 size does not exceed the specified value
    /// </summary>
    /// <param name="minBase64Size">Minimum Base64 size allowed</param>
    /// <param name="unit">Base64 size unit</param>
    /// <param name="unitDisplayName">Base64 size unit to display in error message</param>
    public MinBase64SizeAttribute(long minBase64Size,FileSizeUnit unit,string? unitDisplayName = null) : base(ValidationErrorMessages.MinBase64SizeErrorMessage)
    {
        UnitDisplayName = unitDisplayName ?? unit.GetDisplayName();
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
        return MinBase64Size.ToByte(Unit) <= data.Length;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinBase64Size,UnitDisplayName);
}