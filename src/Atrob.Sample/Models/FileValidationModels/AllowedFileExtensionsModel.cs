using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class AllowedFileExtensionsModel
{
    [Display(Name = "Avatar")]
    [AllowedFileExtensions("image/png", "image/jpeg", ErrorMessage = "{1} extensions are allowed for the {0} image")]
    public IFormFile? File { get; set; }
}