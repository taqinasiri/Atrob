using Atrob.CollectionValidation;

namespace Atrob.Sample.Models.CollectionValidationModels;

public class CollectionCountItemsModel
{
    [Display(Name = "Foods")]
    [CollectionCountItems(3, ErrorMessage = "You can only choose {1} items for {0}")]
    public List<string> Collection { get; set; } = new List<string>();
}

