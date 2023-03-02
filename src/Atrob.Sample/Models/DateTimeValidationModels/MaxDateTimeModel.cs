using Atrob.DateTimeValidation;

namespace Atrob.Sample.Models.DateTimeValidationModels;

public class MaxDateTimeModel
{
    [Display(Name = "Date of birth")]
    [MaxDateTime(2023,2,13,15,10)]
    public DateTime DateTime { get; set; }
}


