namespace Atrob.Test.Data;

internal static class Base64Generator
{
    public static string? GenerateBase64String(int byteSize)
    {
        byte[] data = new byte[byteSize];
        Random random = new Random();
        random.NextBytes(data);

        string base64String = Convert.ToBase64String(data);

        return base64String;
    }
}