namespace Atrob.Validations.Base64;

/// <summary>
/// Checks that it is a base64 string
/// </summary>
public class Base64StringAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Checks that it is a base64 string
    /// </summary>
    public Base64StringAttribute() : base(ValidationErrorMessages.Base64String) { }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        string base64 = value as string ?? string.Empty;
        try
        {
            Convert.FromBase64String(base64);
            return true;
        }
        catch
        {
            return false;
        }
    }
}