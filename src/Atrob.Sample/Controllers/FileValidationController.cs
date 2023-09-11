using Atrob.Validations.File;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FileValidationController : ControllerBase
{
    [HttpPost]
    public IActionResult FileRequired([FileRequired] IFormFile file) => Ok();

    [HttpPost]
    public IActionResult FileNotEmpty([FileNotEmpty] IFormFile? file) => Ok();

    ///<summary>
    /// Max Size : 100 KB
    ///</summary>   
    [HttpPost]
    public IActionResult MaxFileSize([MaxFileSize(100, Enums.FileSizeUnit.Kilobyte, "KB")] IFormFile? file) => Ok();

    /// <summary>
    /// Min Size : 100 KB
    /// </summary>
    [HttpPost]
    public IActionResult MinFileSize([MinFileSize(100, Enums.FileSizeUnit.Kilobyte, "KB")] IFormFile? file) => Ok();

    /// <summary>
    /// Max Size : 500 KB | Min Size : 50 KB
    /// </summary>
    [HttpPost]
    public IActionResult RangeFileSize([RangeFileSize(500, 50, Enums.FileSizeUnit.Kilobyte, "KB")] IFormFile? file) => Ok();


    /// <summary>
    /// Allowed ContentTypes : image/png , image/jpeg
    /// </summary>
    [HttpPost]
    public IActionResult AllowedFileExtensions([AllowedFileExtensions(false, new[] { "image/png", "image/jpeg" })] IFormFile? file) => Ok();

    /// <summary>
    /// Not Allowed ContentTypes : image/png , image/jpeg
    /// </summary>
    [HttpPost]
    public IActionResult NotAllowedFileExtensions([NotAllowedFileExtensions(false, new[] { "image/png", "image/jpeg" })] IFormFile? file) => Ok();
}
