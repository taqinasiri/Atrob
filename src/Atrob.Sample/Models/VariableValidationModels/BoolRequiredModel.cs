using Atrob.VariableValidation;

namespace Atrob.Sample.Models.VariableValidationModels;

public class BoolRequiredModel
{
    [Display(Name = "Acceptance of rules and regulations")]
    [BoolRequired(ErrorMessage = "{0} is required")]
    public bool Check { get; set; }
}
