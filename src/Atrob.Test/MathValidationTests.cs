using Atrob.MathValidation;
using System.ComponentModel.DataAnnotations;

namespace Atrob.Test;

public class MathValidationTests
{
    [Theory]
    [InlineData(10)]
    [InlineData(9)]
    [InlineData(40)]
    [InlineData(52,false)]
    [InlineData("9",false)]
    [InlineData("Atrob",false)]
    [InlineData(9.2,false)]
    public void DivisibilityAttributeTest(object number,bool result = true)
    {
        //arrange
        var attribute = new DivisibilityAttribute(3,5,8);
        //act
        var isValid = attribute.IsValid(number);
        //assert
        Assert.Equal(result,isValid);
    }
}