using Atrob.Validations.Variable;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class VariableValidationController : ControllerBase
{
    [HttpPost]
    public IActionResult FileRequired([TrueRequired] bool isTrue) => Ok();
}