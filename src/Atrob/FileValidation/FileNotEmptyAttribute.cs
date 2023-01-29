namespace Atrob.FileValidation;

/// <summary>
/// Checks if the file is more than 0 bytes
/// </summary>
public class FileNotEmptyAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileNotEmptyAttribute"/> class.
    /// </summary>
    public FileNotEmptyAttribute() : base(ErrorMessages.FileNotEmptyErrorMessage) { }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        if (file is not null && file.Length == 0) return false;
        return true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-fileNotEmpty", FormatErrorMessage(context.ModelMetadata.DisplayName));
    }
}

