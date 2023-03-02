using Atrob.CollectionValidation;

namespace Atrob.Sample.Models.CollectionValidationModels;

public class CollectionMaxAndMinItemsModel
{
    [Display(Name = "Foods")]
    //[CollectionMaxAndMinItems(2,4)] //throw Exception
    [CollectionRangeItems(5, 3, ErrorMessage = "You can choose between {1} and {2} {0}")]
    public List<string> Collection { get; set; } = new List<string>();
}
