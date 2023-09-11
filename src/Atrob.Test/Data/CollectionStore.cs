namespace Atrob.Test.Data;
public static class CollectionStore
{
    public static IEnumerable<string>? GenerateIEnumerable(int allItemsCount,int nullItemsCount = 0)
    {
        int nullsCount = 0;
        for(int i = 0; i < allItemsCount; i++)
            if(nullsCount < nullItemsCount)
            {
                yield return null!;
                nullsCount++;
            }
            else
                yield return $"Item {i}";
    }
}
