using Atrob.DateTimeValidation;

namespace Atrob.Sample.Models.DateTimeValidationModels;

public class MinDateModel
{
    [Display(Name = "Date of birth")]
    [MinDate(2023,2,13)]
    [DataType(DataType.Date)]
    public DateOnly Date { get; set; }
}


