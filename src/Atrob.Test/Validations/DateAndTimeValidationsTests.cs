using Atrob.Validations.DateAndTime;

namespace Atrob.Test.Validations;

public class DateAndTimeValidationsTests
{
    #region Max Date

    [Theory]
    [InlineData(true,0)]
    [InlineData(true,-1)]
    [InlineData(true,-1000)]
    [InlineData(false,1)]
    [InlineData(false,1000)]
    public void Max_Date_Default_Constructor_Test(bool expectedResult,int addDays)
    {
        //arrange
        var attribute = new MaxDateAttribute();
        //act
        var isValidDateOnly = attribute.IsValid(DateOnly.FromDateTime(DateTime.Now.AddDays(addDays)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddDays(addDays));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,10,0)]
    [InlineData(true,10,-1)]
    [InlineData(true,10,-1000)]
    [InlineData(false,10,11)]
    [InlineData(false,10,1000)]
    public void Max_Date_AddDays_Constructor_Test(bool expectedResult,int exAddDays,int addDays)
    {
        //arrange
        var attribute = new MaxDateAttribute(exAddDays);
        //act
        var isValidDateOnly = attribute.IsValid(DateOnly.FromDateTime(DateTime.Now.AddDays(addDays)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddDays(addDays));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,2023,10,14,2023,10,14)]
    [InlineData(true,2023,10,14,2023,5,14)]
    [InlineData(true,2023,10,14,2016,5,14)]
    [InlineData(false,2023,10,14,2023,12,14)]
    [InlineData(false,2023,10,14,2025,12,14)]
    public void Max_Date_Year_Month_Day_Constructor_Test(bool expectedResult,int exYear,int exMonth,int exDay,int year,int month,int day)
    {
        //arrange
        var attribute = new MaxDateAttribute(exYear,exMonth,exDay);
        //act
        var isValidDateOnly = attribute.IsValid(new DateOnly(year,month,day));
        var isValidDateTime = attribute.IsValid(new DateTime(year,month,day));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,"2023/10/14",2023,10,14)]
    [InlineData(true,"2023/10/14",2023,5,14)]
    [InlineData(true,"2023/10/14",2016,5,14)]
    [InlineData(false,"2023/10/14",2023,12,14)]
    [InlineData(false,"2023/10/14",2025,12,14)]
    public void Max_Date_StringDate_Constructor_Test(bool expectedResult,string date,int year,int month,int day)
    {
        //arrange
        var attribute = new MaxDateAttribute(date);
        //act
        var isValidDateOnly = attribute.IsValid(new DateOnly(year,month,day));
        var isValidDateTime = attribute.IsValid(new DateTime(year,month,day));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    #endregion Max Date

    #region Min Date

    [Theory]
    [InlineData(true,0)]
    [InlineData(true,1)]
    [InlineData(true,1000)]
    [InlineData(false,-1)]
    [InlineData(false,-1000)]
    public void Min_Date_Default_Constructor_Test(bool expectedResult,int addDays)
    {
        //arrange
        var attribute = new MinDateAttribute();
        //act
        var isValidDateOnly = attribute.IsValid(DateOnly.FromDateTime(DateTime.Now.AddDays(addDays)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddDays(addDays));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,10,10)]
    [InlineData(true,10,11)]
    [InlineData(true,10,1000)]
    [InlineData(false,10,-1)]
    [InlineData(false,10,-1000)]
    public void Min_Date_AddDays_Constructor_Test(bool expectedResult,int exAddDays,int addDays)
    {
        //arrange
        var attribute = new MinDateAttribute(exAddDays);
        //act
        var isValidDateOnly = attribute.IsValid(DateOnly.FromDateTime(DateTime.Now.AddDays(addDays)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddDays(addDays));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,2023,10,14,2023,10,14)]
    [InlineData(true,2023,10,14,2023,12,14)]
    [InlineData(true,2023,10,14,2025,12,14)]
    [InlineData(false,2023,10,14,2023,5,14)]
    [InlineData(false,2023,10,14,2016,5,14)]
    public void Min_Date_Year_Month_Day_Constructor_Test(bool expectedResult,int exYear,int exMonth,int exDay,int year,int month,int day)
    {
        //arrange
        var attribute = new MinDateAttribute(exYear,exMonth,exDay);
        //act
        var isValidDateOnly = attribute.IsValid(new DateOnly(year,month,day));
        var isValidDateTime = attribute.IsValid(new DateTime(year,month,day));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,"2023/10/14",2023,10,14)]
    [InlineData(true,"2023/10/14",2023,12,14)]
    [InlineData(true,"2023/10/14",2025,12,14)]
    [InlineData(false,"2023/10/14",2023,5,14)]
    [InlineData(false,"2023/10/14",2016,5,14)]
    public void Min_Date_StringDate_Constructor_Test(bool expectedResult,string date,int year,int month,int day)
    {
        //arrange
        var attribute = new MinDateAttribute(date);
        //act
        var isValidDateOnly = attribute.IsValid(new DateOnly(year,month,day));
        var isValidDateTime = attribute.IsValid(new DateTime(year,month,day));
        //assert
        Assert.Equal(expectedResult,isValidDateOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    #endregion Min Date
}