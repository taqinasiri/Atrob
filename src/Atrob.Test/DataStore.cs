namespace Atrob.Test;
public static class DataStore
{
    public static IEnumerable<string> GenerateIEnumerable(int items)
    {
        for (int i = 0; i < items; i++)
        {
            yield return $"Item {i}";
        }
    }
    
}
