using Atrob.Validations.DateAndTime;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DateAndTimeValidationController : ControllerBase
{
    /// <summary>
    /// Max Date : 10/14/2023
    /// </summary>
    [HttpPost]
    public IActionResult MaxDate([MaxDate(2023,10,14)] DateOnly date) => Ok();

    /// <summary>
    /// Min Date : 10/14/2023
    /// </summary>
    [HttpPost]
    public IActionResult MinDate([MinDate(2023,10,14)] DateOnly date) => Ok();
}