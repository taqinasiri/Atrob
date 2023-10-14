namespace Atrob.Validations.File;

/// <summary>
/// Checks that the file is imported and its size is greater than 0 bytes
/// </summary>
public class FileRequiredAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Checks that the file is imported and its size is greater than 0 bytes
    /// </summary>
    public FileRequiredAttribute() : base(ValidationErrorMessages.RequiredFileErrorMessage) { }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return file is not null && file.Length > 0;
    }
}