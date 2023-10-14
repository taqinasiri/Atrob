using Atrob.Validations.Math;

namespace Atrob.Test.Validations;

public class MathValidationTests
{
    [Theory]
    [InlineData(true,10,2)]
    [InlineData(true,15,5,6)]
    [InlineData(false,8,3)]
    [InlineData(false,17,5,3)]
    public void Divisibility_Test(bool expectedResult,int value,params int[] numbersDivisible)
    {
        //arrange
        var attribute = new DivisibilityAttribute(numbersDivisible);
        //act
        var isValid = attribute.IsValid(value);
        //assert
        Assert.Equal(expectedResult,isValid);
    }
}