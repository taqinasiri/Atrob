using Atrob.Sample.Models.CollectionValidationModels;

namespace Atrob.Sample.Controllers;
public class CollectionValidationController : Controller
{
    #region CollectionCountItems
    public IActionResult CollectionCountItems() => View();
    [HttpPost]
    public IActionResult CollectionCountItems(CollectionCountItemsModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region CollectionMaxItems
    public IActionResult CollectionMaxItems() => View();
    [HttpPost]
    public IActionResult CollectionMaxItems(CollectionMaxItemsModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region CollectionMinItems
    public IActionResult CollectionMinItems() => View();
    [HttpPost]
    public IActionResult CollectionMinItems(CollectionMinItemsModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region CollectionMaxAndMinItems
    public IActionResult CollectionMaxAndMinItems() => View();
    [HttpPost]
    public IActionResult CollectionMaxAndMinItems(CollectionMaxAndMinItemsModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

}

