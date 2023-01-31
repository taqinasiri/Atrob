namespace Atrob.VariableValidation;

/// <summary>
/// It checks that a boolean must have the 'true' value
/// </summary>
public class BoolRequiredAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BoolRequiredAttribute"/> class.
    /// </summary>
    public BoolRequiredAttribute() : base(ErrorMessages.BoolValidationErrorMessage) { }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        try
        {
            var status = (bool)(value ?? false);
            return status;
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
        context.MergeAttribute("data-val-boolValidation", FormatErrorMessage(context.ModelMetadata.DisplayName));
    }
}

