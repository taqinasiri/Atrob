using Atrob.DateTimeValidation;

namespace Atrob.Sample.Models.DateTimeValidationModels;

public class MinDateTimeModel
{
    [Display(Name = "Date of birth")]
    [MinDateTime(2023,2,13,15,10)]
    public DateTime DateTime { get; set; }
}


