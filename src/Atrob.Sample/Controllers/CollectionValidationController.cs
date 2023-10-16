using Atrob.Validations.Collection;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CollectionValidationController : ControllerBase
{
    /// <summary>
    /// Max Items : 5
    /// </summary>
    [HttpPost]
    public IActionResult MaxCollectionItems([MaxCollectionItems(5)] List<string>? names) => Ok();

    /// <summary>
    /// Min Items : 5
    /// </summary>
    [HttpPost]
    public IActionResult MinCollectionItems([MinCollectionItems(5)] List<string>? names) => Ok();

    /// <summary>
    /// Max Items : 10 | Min Items : 5
    /// </summary>
    [HttpPost]
    public IActionResult RangeCollectionItems([RangeCollectionItems(10,5)] List<string>? names) => Ok();
}