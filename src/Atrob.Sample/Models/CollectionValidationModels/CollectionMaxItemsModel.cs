using Atrob.CollectionValidation;

namespace Atrob.Sample.Models.CollectionValidationModels;

public class CollectionMaxItemsModel
{
    [Display(Name = "Foods")]
    [CollectionMaxItems(2, ErrorMessage = "A maximum of {0} items is allowed for {1}")]
    public List<string> Collection { get; set; } = new List<string>();
}

