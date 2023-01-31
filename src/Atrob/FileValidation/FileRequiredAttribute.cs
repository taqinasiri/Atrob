namespace Atrob.FileValidation;

/// <summary>
/// Checks if a file is imported and is more than 0 bytes
/// </summary>
public class FileRequiredAttribute : ValidationAttributeBase, IClientModelValidator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationAttributeBase"/> class.
    /// </summary>
    public FileRequiredAttribute() : base(ErrorMessages.RequiredFileErrorMessage) { }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return (file is null || file.Length == 0) ? false : true;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-fileRequired", FormatErrorMessage(context.ModelMetadata.DisplayName));
    }
}

