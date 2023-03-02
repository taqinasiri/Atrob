using Atrob.DateTimeValidation;

namespace Atrob.Test;

public class DateTimeValidationTests
{
    [Theory]
    [InlineData(-5)]
    [InlineData(-100)]
    [InlineData(0)]
    [InlineData(0, -1)]
    [InlineData(100, 0, false)]
    [InlineData(5, 0, false)]
    public void MaxDateTimeAttributeTest(int AddDays, int AddMinute = 0, bool result = true)
    {
        DateTime dateTime = DateTime.Now;
        //arrange
        var attribute = new MaxDateTimeAttribute(dateTime.Year, dateTime.Month, dateTime.Day);
        dateTime = dateTime.AddDays(AddDays).AddMinutes(AddMinute);
        //act
        var isValid = attribute.IsValid(dateTime);
        //assert
        Assert.Equal(result, isValid);
    }


    [Theory]
    [InlineData(5)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(0, 1)]
    [InlineData(-100, 0, false)]
    [InlineData(-5, 0, false)]
    public void MinDateTimeAttributeTest(int AddDays, int AddMinute = 0, bool result = true)
    {
        DateTime dateTime = DateTime.Now;
        //arrange
        var attribute = new MinDateTimeAttribute(dateTime.Year, dateTime.Month, dateTime.Day);
        dateTime = dateTime.AddDays(AddDays).AddMinutes(AddMinute);
        //act
        var isValid = attribute.IsValid(dateTime);
        //assert
        Assert.Equal(result, isValid);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(-100)]
    [InlineData(0)]
    [InlineData(100, false)]
    [InlineData(5, false)]
    public void MaxDateAttributeTest(int AddDays, bool result = true)
    {
        DateTime dateTime = DateTime.Now;
        //arrange
        var attribute = new MaxDateAttribute(dateTime.Year, dateTime.Month, dateTime.Day);
        dateTime = dateTime.AddDays(AddDays);
        //act
        var isValid = attribute.IsValid(dateTime);
        //assert
        Assert.Equal(result, isValid);
    }


    [Theory]
    [InlineData(5)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-100, false)]
    [InlineData(-5, false)]
    public void MinDateAttributeTest(int AddDays, bool result = true)
    {
        DateTime dateTime = DateTime.Now;
        //arrange
        var attribute = new MinDateAttribute(dateTime.Year, dateTime.Month, dateTime.Day);
        dateTime = dateTime.AddDays(AddDays);
        //act
        var isValid = attribute.IsValid((dateTime));
        //assert
        Assert.Equal(result, isValid);
    }
}