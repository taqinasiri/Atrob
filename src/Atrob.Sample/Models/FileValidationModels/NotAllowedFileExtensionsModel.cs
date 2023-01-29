using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class NotAllowedFileExtensionsModel
{
    [Display(Name = "Test")]
    [NotAllowedFileExtensions("image/gif", "application/pdf", ErrorMessage = "{1} extensions are not allowed for the {0}")]
    public IFormFile? File { get; set; }
}