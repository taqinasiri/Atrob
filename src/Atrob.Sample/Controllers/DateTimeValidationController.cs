using Atrob.Sample.Models.DateTimeValidationModels;

namespace Atrob.Sample.Controllers;
public class DateTimeValidationController : Controller
{
    #region MaxDateTime
    public IActionResult MaxDateTime() => View();
    [HttpPost]
    public IActionResult MaxDateTime(MaxDateTimeModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region MinDateTime
    public IActionResult MinDateTime() => View();
    [HttpPost]
    public IActionResult MinDateTime(MinDateTimeModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region MaxDate
    public IActionResult MaxDate() => View();
    [HttpPost]
    public IActionResult MaxDate(MaxDateModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region MinDate
    public IActionResult MinDate() => View();
    [HttpPost]
    public IActionResult MinDate(MinDateModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion
}

