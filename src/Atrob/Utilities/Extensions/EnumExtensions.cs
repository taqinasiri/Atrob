namespace Atrob.Utilities.Extensions;

internal static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        if(fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute),false) is DisplayAttribute[] displayAttribute && displayAttribute.Length > 0)
            return displayAttribute[0].Name ?? value.ToString();

        return value.ToString();
    }
}