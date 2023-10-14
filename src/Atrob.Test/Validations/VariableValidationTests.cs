using Atrob.Validations.Variable;

namespace Atrob.Test.Validations;

public class VariableValidationTests
{
    [Theory]
    [InlineData(true,true)]
    [InlineData(false,false)]
    [InlineData(false,null)]
    public void True_Required_Test(bool expectedResult,bool? value)
    {
        //arrange
        var attribute = new TrueRequiredAttribute();
        //act
        var isValid = attribute.IsValid(value);
        //assert
        Assert.Equal(expectedResult,isValid);
    }
}