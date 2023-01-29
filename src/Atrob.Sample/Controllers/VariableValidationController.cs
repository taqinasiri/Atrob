using Atrob.Sample.Models.VariableValidationModels;

namespace Atrob.Sample.Controllers;
public class VariableValidationController : Controller
{
    #region BoolRequired
    public IActionResult BoolRequired() => View();
    [HttpPost]
    public IActionResult BoolRequired(BoolRequiredModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion
}

