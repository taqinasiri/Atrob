using Atrob.Sample.Models.MathValidationModels;

namespace Atrob.Sample.Controllers;
public class MathValidationController : Controller
{
    #region Divisibility
    public IActionResult Divisibility() => View();
    [HttpPost]
    public IActionResult Divisibility(DivisibilityModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion
}

