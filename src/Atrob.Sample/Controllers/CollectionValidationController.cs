using Atrob.Validations.Collection;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CollectionValidationController : ControllerBase
{
    /// <summary>
    /// Max Items : 5
    /// </summary>
    /// <param name="names"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult CollectionMaxItems([CollectionMaxItems(5)] List<string>? names) => Ok();
}
