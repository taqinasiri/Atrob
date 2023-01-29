using Atrob.Sample.Models.FileValidationModels;

namespace Atrob.Client.Sample.Controllers;

public class FileValidationController : Controller
{
    #region Required
    public IActionResult Required() => View();
    [HttpPost]
    public IActionResult Required(RequiredFileModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region MaxFileSize
    public IActionResult MaxFileSize() => View();
    [HttpPost]
    public IActionResult MaxFileSize(MaxFileSizeModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region MinFileSize
    public IActionResult MinFileSize() => View();
    [HttpPost]
    public IActionResult MinFileSize(MinFileSizeModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region MaxAndMinFileSize
    public IActionResult MaxAndMinFileSize() => View();
    [HttpPost]
    public IActionResult MaxAndMinFileSize(MaxAndMinFileSizeModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region AllowedFileExtensions
    public IActionResult AllowedFileExtensions() => View();
    [HttpPost]
    public IActionResult AllowedFileExtensions(AllowedFileExtensionsModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region NotAllowedFileExtensions
    public IActionResult NotAllowedFileExtensions() => View();
    [HttpPost]
    public IActionResult NotAllowedFileExtensions(NotAllowedFileExtensionsModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

    #region FileNotEmpty
    public IActionResult FileNotEmpty() => View();
    [HttpPost]
    public IActionResult FileNotEmpty(FileNotEmptyModel model) => ModelState.IsValid ? View("Success") : View(model);
    #endregion

}