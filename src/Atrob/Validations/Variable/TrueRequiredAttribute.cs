namespace Atrob.Validations.Variable;

/// <summary>
/// It checks that a boolean must have the 'true' value
/// </summary>
public class TrueRequiredAttribute : ValidationAttributeBase
{
    /// <summary>
    /// It checks that a boolean must have the 'true' value
    /// </summary>
    public TrueRequiredAttribute() : base(ValidationErrorMessages.TrueRequiredErrorMessage)
    {
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        try
        {
            return (bool)(value ?? false);
        }
        catch(InvalidCastException)
        {
            return false;
        }
    }
}