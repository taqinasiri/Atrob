using Atrob.Enums;
using Atrob.Test.Data;
using Atrob.Validations.Base64;
using Atrob.Validations.File;
using Microsoft.AspNetCore.Http;

namespace Atrob.Test.Validations;

public class Base64ValidationsTests
{
    [Theory]
    [InlineData(true,"QXRyb2I=")]
    [InlineData(false,"Atrob")]
    public void Base64_String_Test(bool expectedResult,string base64)
    {
        //arrange
        var attribute = new Base64StringAttribute();
        //act
        var isValid = attribute.IsValid(base64);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,100,FileSizeUnit.Byte,50)]
    [InlineData(true,100,FileSizeUnit.Byte,100)]
    [InlineData(true,1,FileSizeUnit.Kilobyte,1023)]
    [InlineData(false,50,FileSizeUnit.Byte,100)]
    [InlineData(false,1,FileSizeUnit.Kilobyte,1025)]
    public void Max_Base64_Size_Test(bool expectedResult,int maxSize,FileSizeUnit unit,int base64Size)
    {
        //arrange
        var attribute = new MaxBase64SizeAttribute(maxSize,unit);
        var base64 = Base64Generator.GenerateBase64String(base64Size);
        //act
        var isValid = attribute.IsValid(base64);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,50,FileSizeUnit.Byte,100)]
    [InlineData(true,100,FileSizeUnit.Byte,100)]
    [InlineData(true,1,FileSizeUnit.Kilobyte,1025)]
    [InlineData(false,100,FileSizeUnit.Byte,50)]
    [InlineData(false,1,FileSizeUnit.Kilobyte,1023)]
    public void Min_Base64_Size_Test(bool expectedResult,int minSize,FileSizeUnit unit,int base64Size)
    {
        //arrange
        var attribute = new MinBase64SizeAttribute(minSize,unit);
        var base64 = Base64Generator.GenerateBase64String(base64Size);
        //act
        var isValid = attribute.IsValid(base64);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,100,50,FileSizeUnit.Byte,75)]
    [InlineData(true,100,50,FileSizeUnit.Byte,100)]
    [InlineData(true,100,50,FileSizeUnit.Byte,50)]
    [InlineData(true,2,1,FileSizeUnit.Kilobyte,2000)]
    [InlineData(false,100,50,FileSizeUnit.Byte,101)]
    [InlineData(false,100,50,FileSizeUnit.Byte,49)]
    [InlineData(false,2,1,FileSizeUnit.Kilobyte,1023)]
    [InlineData(false,2,1,FileSizeUnit.Kilobyte,2049)]
    public void Range_Base64_Size_Test(bool expectedResult,int maxSize,int minSize,FileSizeUnit unit,int base64Size)
    {
        //arrange
        var attribute = new RangeBase64SizeAttribute(maxSize,minSize,unit);
        var base64 = Base64Generator.GenerateBase64String(base64Size);
        //act
        var isValid = attribute.IsValid(base64);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(50,100,FileSizeUnit.Byte)]
    public void Range_Base64_Size_Throw_Exception_Test(int maxSize,int minSize,FileSizeUnit unit)
        => Assert.Throws<ArgumentException>(() => new RangeBase64SizeAttribute(maxSize,minSize,unit));

    [Theory]
    [InlineData(true,false,new string[] { "image/png","image/gif" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(true,true,new string[] { ".png",".gif" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(true,true,new string[] { "png","jpg" },"iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAADElEQVR42mP4z8AAAAMBAQD3A0FDAAAAAElFTkSuQmCC")]
    [InlineData(false,true,new string[] { "png","pdf" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(false,true,new string[] { ".png",".pdf" },"/9j/4AAQSkZJRgABAQAAZABkAAD/2wCEABQQEBkSGScXFycyJh8mMi4mJiYmLj41NTU1NT5EQUFBQUFBRERERERERERE")]
    [InlineData(false,false,new string[] { "image/png",".jpeg" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(false,true,new string[] { ".png","image/jpeg" },"JVBERi0xLjUKJYCBgoMKMSAwIG9iago8PC9GaWx0ZXIvRmxhdGVEZWNvZGUvRmlyc3QgMTQxL04gMjAvTGVuZ3")]
    [InlineData(false,false,new string[] { ".png","image/jpeg" },"iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAADElEQVR42mP4z8AAAAMBAQD3A0FDAAAAAElFTkSuQmCC")]
    public void Allowed_File_Extensions_Test(bool expectedResult,bool isExtension,string[] allowedContentTypes,string base64)
    {
        //arrange
        var attribute = new AllowedBase64FileExtensionsAttribute(isExtension,allowedContentTypes);
        //act
        var isValid = attribute.IsValid(base64);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,true,new string[] { "png","pdf" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(true,true,new string[] { ".png",".pdf" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(true,false,new string[] { "image/png","image/jpeg" },"JVBERi0xLjUKJYCBgoMKMSAwIG9iago8PC9GaWx0ZXIvRmxhdGVEZWNvZGUvRmlyc3QgMTQxL04gMjAvTGVuZ3")]
    [InlineData(true,true,new string[] { ".png","image/jpeg" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(true,false,new string[] { ".png","image/jpeg" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(false,false,new string[] { "image/png","image/jpeg" },"iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAADElEQVR42mP4z8AAAAMBAQD3A0FDAAAAAElFTkSuQmCC")]
    [InlineData(false,true,new string[] { ".png",".gif" },"R0lGODdhAQABAPAAAP8AAAAAACwAAAAAAQABAAACAkQBADs=")]
    [InlineData(false,true,new string[] { "png","jpg" },"iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAADElEQVR42mP4z8AAAAMBAQD3A0FDAAAAAElFTkSuQmCC")]
    public void Not_Allowed_File_Extensions_Test(bool expectedResult,bool isExtension,string[] allowedContentTypes,string base64)
    {
        //arrange
        var attribute = new NotAllowedBase64FileExtensionsAttribute(isExtension,allowedContentTypes);
        //act
        var isValid = attribute.IsValid(base64);
        //assert
        Assert.Equal(expectedResult,isValid);
    }
}