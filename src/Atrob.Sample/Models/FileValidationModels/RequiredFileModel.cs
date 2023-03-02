using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class RequiredFileModel
{
    [Display(Name = "Avatar")]
    [FileRequired(ErrorMessage = "please upload your {0}")]
    public IFormFile File { get; set; } = null!;
}