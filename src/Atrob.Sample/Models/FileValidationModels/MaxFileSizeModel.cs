using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class MaxFileSizeModel
{
    [Display(Name = "Avatar")]
    [MaxFileSize(0.5, ErrorMessage = "{0} size cannot be larger than {1} MB")]
    public IFormFile? File { get; set; }
}