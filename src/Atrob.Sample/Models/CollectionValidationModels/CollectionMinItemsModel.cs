using Atrob.CollectionValidation;

namespace Atrob.Sample.Models.CollectionValidationModels;

public class CollectionMinItemsModel
{
    [Display(Name = "Foods")]
    [CollectionMinItems(3, ErrorMessage = "A minimum of {0} items is allowed for {1}")]
    public List<string> Collection { get; set; } = new List<string>();
}

