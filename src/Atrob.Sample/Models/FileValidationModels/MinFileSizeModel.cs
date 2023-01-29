using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class MinFileSizeModel
{
    [Display(Name = "Avatar")]
    [MinFileSize(0.5, ErrorMessage = "{0} size cannot be smaller than {1} MB")]
    public IFormFile? File { get; set; }
}