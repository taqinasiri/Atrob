using System.Globalization;

namespace Atrob.Validations.Math;

/// <summary>
/// Checks that a number is divisible by numbers
/// </summary>
public class DivisibilityAttribute : ValidationAttributeBase
{
    /// <summary>
    /// array of numbers that must be divisible by one of them
    /// </summary>
    public int[] NumbersDivisible { get; init; }

    /// <summary>
    /// Checks that a number is divisible by numbers
    /// </summary>
    /// <param name="numbersDivisible">array of numbers that must be divisible by one of them</param>
    public DivisibilityAttribute(params int[] numbersDivisible) : base(ValidationErrorMessages.DivisibilityErrorMessage)
        => NumbersDivisible = numbersDivisible;

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var number = (int)(value ?? 0);
        return NumbersDivisible.FirstOrDefault(n => number % n == 0) != 0;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,
            string.Join(", ",NumbersDivisible));
}