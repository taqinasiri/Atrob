using Atrob.FileValidation;

namespace Atrob.Sample.Models.FileValidationModels;

public class MaxAndMinFileSizeModel
{
    [Display(Name = "Avatar")]
    //[MaxAndMinFileSize(1,2)] //throw Exception
    [RangeFileSize(1, 0.5)]
    public IFormFile? File { get; set; }
}