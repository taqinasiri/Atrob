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

    /// <summary>
    /// Max Time : 22:30:15
    /// </summary>
    [HttpPost]
    public IActionResult MaxTime([MaxTime(22,30,15)] TimeOnly time) => Ok();

    /// <summary>
    /// Min Time : 22:30:15
    /// </summary>
    [HttpPost]
    public IActionResult MinTime([MinTime(22,30,15)] TimeOnly time) => Ok();

    /// <summary>
    /// Max DateTime : 10/14/2023 22:30:15
    /// </summary>
    [HttpPost]
    public IActionResult MaxDateTime([MaxDateTime(2023,10,14,22,30,15)] DateTime dateTime) => Ok();

    /// <summary>
    /// Min DateTime : 10/14/2023 22:30:15
    /// </summary>
    [HttpPost]
    public IActionResult MinDateTime([MinDateTime(2023,10,14,22,30,15)] DateTime dateTime) => Ok();
}