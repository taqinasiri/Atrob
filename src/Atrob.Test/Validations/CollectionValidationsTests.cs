using Atrob.Test.Data;
using Atrob.Validations.Collection;

namespace Atrob.Test.Validations;
public class CollectionValidationsTests
{

    [Theory]
    [InlineData(true,5,2)]
    [InlineData(true,5,5)]
    [InlineData(true,5,null)]
    [InlineData(true,5,10,true,6)]
    [InlineData(false,5,6)]
    [InlineData(false,5,10,false,6)]
    public void Collection_Max_Items_Test(bool expectedResult,int maxItems,int? collectionItemsCount,bool isRemoveNulls = true,int nullCount = 0)
    {
        //arrange
        var attribute = new CollectionMaxItemsAttribute(maxItems,isRemoveNulls);
        var collection = collectionItemsCount is null ? null : CollectionStore.GenerateIEnumerable(collectionItemsCount.Value,nullCount);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,5,10)]
    [InlineData(true,5,5)]
    [InlineData(true,5,null)]
    [InlineData(true,5,10,false,6)]
    [InlineData(false,5,4)]
    [InlineData(false,5,10,true,6)]
    public void Collection_Min_Items_Test(bool expectedResult,int minItems,int? collectionItemsCount,bool isRemoveNulls = true,int nullCount = 0)
    {
        //arrange
        var attribute = new CollectionMinItemsAttribute(minItems,isRemoveNulls);
        var collection = collectionItemsCount is null ? null : CollectionStore.GenerateIEnumerable(collectionItemsCount.Value,nullCount);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(expectedResult,isValid);
    }
}
