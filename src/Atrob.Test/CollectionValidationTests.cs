using Atrob.CollectionValidation;

namespace Atrob.Test;

public class CollectionValidationTests
{
    [Theory]
    [InlineData(3, 3)]
    [InlineData(5, 3, false)]
    public void CollectionCountItemsAttributeTest(int selectedItems, int validCount, bool result = true)
    {
        //arrange
        var attribute = new CollectionCountItemsAttribute(validCount);
        var collection = DataStore.GenerateIEnumerable(selectedItems);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(result, isValid);
    }

    [Theory]
    [InlineData(5, 2)]
    [InlineData(2, 2)]
    [InlineData(2, 5, false)]
    public void CollectionMaxItemsAttributeTest(int validMaxItems, int selectedItems, bool result = true)
    {
        //arrange
        var attribute = new CollectionMaxItemsAttribute(validMaxItems);
        var collection = DataStore.GenerateIEnumerable(selectedItems);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(result, isValid);
    }

    [Theory]
    [InlineData(2, 5)]
    [InlineData(2, 2)]
    [InlineData(5, 2, false)]
    public void CollectionMinItemsAttributeTest(int validMinItems, int selectedItems, bool result = true)
    {
        //arrange
        var attribute = new CollectionMinItemsAttribute(validMinItems);
        var collection = DataStore.GenerateIEnumerable(selectedItems);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(result, isValid);
    }

    [Theory]
    [InlineData(5, 3, 4)]
    [InlineData(8, 2, 7)]
    [InlineData(7, 3, 8,false)]
    [InlineData(7, 3, 1,false)]
    public void CollectionMaxAndMinItemsAttributeTest(int validMaxItems, int validMinItems, int selectedItems, bool result = true)
    {
        //arrange
        var attribute = new CollectionRangeItemsAttribute(validMaxItems, validMinItems);
        var collection = DataStore.GenerateIEnumerable(selectedItems);
        //act
        var isValid = attribute.IsValid(collection);
        //assert
        Assert.Equal(result, isValid);
    }

    [Theory]
    [InlineData(2,8)]
    public void CollectionMaxAndMinItemsAttributeArgumentErrorTest(int validMaxItems, int validMinItems)
        => Assert.Throws<ArgumentException>(() => new CollectionRangeItemsAttribute(validMaxItems, validMinItems));
}