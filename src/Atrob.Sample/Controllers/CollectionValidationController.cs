using Atrob.Validations.Collection;
using System.ComponentModel.DataAnnotations;

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
}
