namespace Atrob.Utilities.Extensions;

internal static class Base64Extensions
{
    public static string RemoveBase64Header(this string base64)
    {
        var base64Splited = base64.Split(',');
        if(base64Splited.Length > 1)
            return base64Splited[1];
        return base64;
    }

    public static string? GetBase64Extension(this string base64)
    {
        foreach(var t in Base64Signatures.Types)
        {
            if(base64.Contains(t.Key))
            {
                return t.Value;
            }
        }
        return null;
    }
}