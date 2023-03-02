using Atrob.DateTimeValidation;

namespace Atrob.Sample.Models.DateTimeValidationModels;

public class MaxDateModel
{
    [Display(Name = "Date of birth")]
    [MaxDate(2023,2,13)]
    [DataType(DataType.Date)]
    public DateOnly Date { get; set; }
}


