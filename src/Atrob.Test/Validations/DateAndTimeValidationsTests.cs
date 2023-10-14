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

    #region Max Time

    [Theory]
    [InlineData(true,0)]
    [InlineData(true,-1)]
    [InlineData(true,-1000)]
    [InlineData(false,1)]
    [InlineData(false,1000)]
    public void Max_Time_Default_Constructor_Test(bool expectedResult,int addSeconds)
    {
        //arrange
        var attribute = new MaxTimeAttribute();
        //act
        var isValidTimeOnly = attribute.IsValid(TimeOnly.FromDateTime(DateTime.Now.AddSeconds(addSeconds)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddSeconds(addSeconds));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,10,0)]
    [InlineData(true,10,-1)]
    [InlineData(true,10,-1000)]
    [InlineData(false,10,11)]
    [InlineData(false,10,1000)]
    public void Max_Time_AddDays_Constructor_Test(bool expectedResult,int exAddSeconds,int addSeconds)
    {
        //arrange
        var attribute = new MaxTimeAttribute(exAddSeconds);
        //act
        var isValidTimeOnly = attribute.IsValid(TimeOnly.FromDateTime(DateTime.Now.AddSeconds(addSeconds)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddSeconds(addSeconds));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,22,30,15,22,30,15)]
    [InlineData(true,22,30,15,22,30,14)]
    [InlineData(true,22,30,15,16,30,15)]
    [InlineData(false,22,30,15,22,30,16)]
    [InlineData(false,22,30,15,23,30,15)]
    public void Max_Time_Year_Month_Day_Constructor_Test(bool expectedResult,int exHour,int exMinute,int exSecond,int hour,int minute,int second)
    {
        //arrange
        var attribute = new MaxTimeAttribute(exHour,exMinute,exSecond);
        //act
        var isValidTimeOnly = attribute.IsValid(new TimeOnly(hour,minute,second));
        var isValidDateTime = attribute.IsValid(new DateTime(2023,10,14,hour,minute,second));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,"22:30:15",22,30,15)]
    [InlineData(true,"22:30:15",22,30,14)]
    [InlineData(true,"22:30:15",16,30,15)]
    [InlineData(false,"22:30:15",22,30,16)]
    [InlineData(false,"22:30:15",23,30,15)]
    public void Max_Time_StringDate_Constructor_Test(bool expectedResult,string time,int hour,int minute,int second)
    {
        //arrange
        var attribute = new MaxTimeAttribute(time);
        //act
        var isValidTimeOnly = attribute.IsValid(new TimeOnly(hour,minute,second));
        var isValidDateTime = attribute.IsValid(new DateTime(2023,10,14,hour,minute,second));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    #endregion Max Time

    #region Min Time

    [Theory]
    [InlineData(true,1)]
    [InlineData(true,1000)]
    [InlineData(false,-1)]
    [InlineData(false,-1000)]
    public void Min_Time_Default_Constructor_Test(bool expectedResult,int addSeconds)
    {
        //arrange
        var attribute = new MinTimeAttribute();
        //act
        var isValidTimeOnly = attribute.IsValid(TimeOnly.FromDateTime(DateTime.Now.AddSeconds(addSeconds)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddSeconds(addSeconds));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,10,11)]
    [InlineData(true,10,1000)]
    [InlineData(false,10,-1)]
    [InlineData(false,10,-1000)]
    public void Min_Time_AddDays_Constructor_Test(bool expectedResult,int exAddSeconds,int addSeconds)
    {
        //arrange
        var attribute = new MinTimeAttribute(exAddSeconds);
        //act
        var isValidTimeOnly = attribute.IsValid(TimeOnly.FromDateTime(DateTime.Now.AddSeconds(addSeconds)));
        var isValidDateTime = attribute.IsValid(DateTime.Now.AddSeconds(addSeconds));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,22,30,15,22,30,15)]
    [InlineData(true,22,30,15,22,30,16)]
    [InlineData(true,22,30,15,23,30,15)]
    [InlineData(false,22,30,15,22,30,14)]
    [InlineData(false,22,30,15,16,30,15)]
    public void Min_Time_Year_Month_Day_Constructor_Test(bool expectedResult,int exHour,int exMinute,int exSecond,int hour,int minute,int second)
    {
        //arrange
        var attribute = new MinTimeAttribute(exHour,exMinute,exSecond);
        //act
        var isValidTimeOnly = attribute.IsValid(new TimeOnly(hour,minute,second));
        var isValidDateTime = attribute.IsValid(new DateTime(2023,10,14,hour,minute,second));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    [Theory]
    [InlineData(true,"22:30:15",22,30,15)]
    [InlineData(true,"22:30:15",22,30,16)]
    [InlineData(true,"22:30:15",23,30,15)]
    [InlineData(false,"22:30:15",22,30,14)]
    [InlineData(false,"22:30:15",16,30,15)]
    public void Min_Time_StringDate_Constructor_Test(bool expectedResult,string time,int hour,int minute,int second)
    {
        //arrange
        var attribute = new MinTimeAttribute(time);
        //act
        var isValidTimeOnly = attribute.IsValid(new TimeOnly(hour,minute,second));
        var isValidDateTime = attribute.IsValid(new DateTime(2023,10,14,hour,minute,second));
        //assert
        Assert.Equal(expectedResult,isValidTimeOnly);
        Assert.Equal(expectedResult,isValidDateTime);
    }

    #endregion Min Time
}