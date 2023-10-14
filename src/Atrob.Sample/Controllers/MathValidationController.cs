using Atrob.Validations.Math;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MathValidationController : ControllerBase
{
    /// <summary>
    /// Divisibility : 2 , 3
    /// </summary>
    [HttpPost]
    public IActionResult Divisibility([Divisibility(2,3)] int number) => Ok();
}