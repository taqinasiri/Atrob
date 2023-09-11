using Atrob.Utilities.Constants;

namespace Atrob.Validations.File;

/// <summary>
/// Checks that the file size is greater than 0 bytes
/// </summary>
public class FileNotEmptyAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Checks that the file size is greater than 0 bytes
    /// </summary>
    public FileNotEmptyAttribute() : base(ValidationErrorMessages.FileNotEmptyErrorMessage) { }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var file = value as IFormFile;
        return file is null || file.Length > 0;
    }
}