namespace Atrob;

/// <summary>
/// The base abstract class for most Atrob attributes
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public abstract class ValidationAttributeBase : ValidationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationAttribute"/> class.
    /// </summary>
    /// <param name="errorMessage">Changes the default error text</param>
    public ValidationAttributeBase(string? errorMessage = null)
    {
        if (!string.IsNullOrWhiteSpace(errorMessage))
            ErrorMessage = errorMessage;
    }
}

