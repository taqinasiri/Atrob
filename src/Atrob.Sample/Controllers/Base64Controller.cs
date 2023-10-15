using Atrob.Validations.Base64;

namespace Atrob.Sample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Base64Controller : ControllerBase
{
    [HttpPost]
    public IActionResult Base64String([Base64String] string base64) => Ok();

    /// <summary>
    /// Max Size : 50 Byte
    /// </summary>
    [HttpPost]
    public IActionResult MaxBase64Size([MaxBase64Size(50,Enums.FileSizeUnit.Byte)] string base64) => Ok();

    /// <summary>
    /// Min Size : 50 Byte
    /// </summary>
    [HttpPost]
    public IActionResult MinBase64Size([MinBase64Size(50,Enums.FileSizeUnit.Byte)] string base64) => Ok();

    /// <summary>
    /// Range Size : 50 - 100 Byte
    /// </summary>
    [HttpPost]
    public IActionResult RangeBase64Size([RangeBase64Size(100,50,Enums.FileSizeUnit.Byte)] string base64) => Ok();

    /// <summary>
    /// Allowed ContentTypes : image/png , image/jpeg
    /// </summary>
    [HttpPost]
    public IActionResult AllowedBase64FileExtensions([AllowedBase64FileExtensions(false,new[] { "image/png","image/jpeg" })] string base64) => Ok();

    /// <summary>
    /// Not Allowed ContentTypes : image/png , image/jpeg
    /// </summary>
    [HttpPost]
    public IActionResult NotAllowedBase64FileExtensions([NotAllowedBase64FileExtensions(false,new[] { "image/png","image/jpeg" })] string base64) => Ok();
}