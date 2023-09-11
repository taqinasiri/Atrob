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
    public IActionResult CollectionMaxItems([CollectionMaxItems(5)] List<string>? names) => Ok();

    /// <summary>
    /// Min Items : 5
    /// </summary>
    [HttpPost]
    public IActionResult CollectionMinItems([CollectionMinItems(5)] List<string>? names) => Ok();
}
