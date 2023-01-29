using System.Globalization;

namespace Atrob.MathValidation;

/// <summary>
/// Checks that a number is divisible by numbers
/// </summary>
public class DivisibilityAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// An array of numbers that must be divisible by one of them
    /// </summary>
    public int[] NumbersDivisible { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DivisibilityAttribute"/> class.
    /// </summary>
    /// <param name="numbersDivisible">An array of numbers that must be divisible by one of them</param>
    public DivisibilityAttribute(params int[] numbersDivisible) : base(ErrorMessages.DivisibilityErrorMessage)
        => NumbersDivisible = numbersDivisible;

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        try
        {
            var number = (int)(value ?? 0);
            if (NumbersDivisible.FirstOrDefault(n => number % n == 0) == 0) return false;
            return true;
        }
        catch (InvalidCastException)
        {
            return false;
        }
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-divisibility", FormatErrorMessage(context.ModelMetadata.DisplayName));
        context.MergeAttribute("data-val-numbersdivisible", string.Join(',', NumbersDivisible));
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name,
            string.Join(", ", NumbersDivisible));
}

