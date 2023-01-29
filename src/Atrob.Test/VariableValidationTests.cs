using Atrob.VariableValidation;
using System.ComponentModel.DataAnnotations;

namespace Atrob.Test;

public class VariableValidationTests
{
    [Theory]
    [InlineData(true)]
    [InlineData("true",false)]
    [InlineData("Atrob",false)]
    public void BoolRequiredAttributeTest(object value,bool result = true)
    {
        //arrange
        var attribute = new BoolRequiredAttribute();
        //act
        var isValid = attribute.IsValid(value);
        //assert
        Assert.Equal(result,isValid);
    }
}