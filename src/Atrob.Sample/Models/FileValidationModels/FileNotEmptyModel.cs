using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class FileNotEmptyModel
{
    [Display(Name = "Avatar")]
    [FileNotEmpty(ErrorMessage = "{0} can't be a file without volume")]
    public IFormFile? File { get; set; }
}