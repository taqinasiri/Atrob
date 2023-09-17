using Atrob.Enums;
using Atrob.Test.Data;
using Atrob.Validations.Collection;
using Atrob.Validations.File;

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
    public void Max_Collection_Items_Test(bool expectedResult,int maxItems,int? collectionItemsCount,bool isRemoveNulls = true,int nullCount = 0)
    {
        //arrange
        var attribute = new MaxCollectionItemsAttribute(maxItems,isRemoveNulls);
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
    public void Min_Collection_Items_Test(bool expectedResult,int minItems,int? collectionItemsCount,bool isRemoveNulls = true,int nullCount = 0)
    {
        //arrange
        var attribute = new MinCollectionItemsAttribute(minItems,isRemoveNulls);
        var collection = collectionItemsCount is null ? null : CollectionStore.GenerateIEnumerable(collectionItemsCount.Value,nullCount);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,10,5,7)]
    [InlineData(true,10,5,5)]
    [InlineData(true,10,5,10)]
    [InlineData(true,10,5,12,true,3)]
    [InlineData(true,10,5,7,false,11)]
    [InlineData(false,10,5,4)]
    [InlineData(false,10,5,11)]
    [InlineData(false,10,5,12,false,3)]
    [InlineData(false,10,5,7,true,5)]
    public void Range_Collection_Items_Test(bool expectedResult,int maxItems,int minItems,int? collectionItemsCount,bool isRemoveNulls = true,int nullCount = 0)
    {
        //arrange
        var attribute = new RangeCollectionItemsAttribute(maxItems,minItems,isRemoveNulls);
        var collection = collectionItemsCount is null ? null : CollectionStore.GenerateIEnumerable(collectionItemsCount.Value,nullCount);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(5,10)]
    public void Range_Collection_Items_Throw_Exception_Test(int maxItems,int minItems)
        => Assert.Throws<ArgumentException>(() => new RangeCollectionItemsAttribute(maxItems,minItems));
}
