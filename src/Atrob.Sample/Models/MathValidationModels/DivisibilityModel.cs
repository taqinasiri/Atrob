using Atrob.MathValidation;

namespace Atrob.Sample.Models.MathValidationModels;

public class DivisibilityModel
{
    [Display(Name = "Price")]
    [Divisibility(3, 5, 8)]
    public int Number { get; set; }
}