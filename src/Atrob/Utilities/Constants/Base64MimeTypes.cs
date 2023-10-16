namespace Atrob.Utilities.Constants;

internal static class Base64Signatures
{
    public static Dictionary<string,string> Types = new()
    {
        {"JVBERi0", "application/pdf"},
        {"R0lGODdh", "image/gif"},
        {"R0lGODlh", "image/gif"},
        {"iVBORw0KGgo", "image/png"},
        {"/9j/", "image/jpeg" },
        {"TU0AK", "image/tiff"},
        {"UEs", "application/vnd.openxmlformats-officedocument."},
        {"PK", "application/zip" }
    };
}