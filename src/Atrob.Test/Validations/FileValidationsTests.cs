using Atrob.Enums;
using Atrob.Validations.File;
using Microsoft.AspNetCore.Http;

namespace Atrob.Test.Validations;

public class FileValidationsTests
{
    [Theory]
    [InlineData(true,100)]
    [InlineData(false,0)]
    [InlineData(false,null)]
    public void File_Required_Test(bool expectedResult,int? fileLength)
    {
        //arrange
        var attribute = new FileRequiredAttribute();
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","file.txt");
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,100)]
    [InlineData(true,null)]
    [InlineData(false,0)]
    public void File_Not_Empty_Test(bool expectedResult,int? fileLength)
    {
        //arrange
        var attribute = new FileNotEmptyAttribute();
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","file.txt");
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,100,FileSizeUnit.Byte,50)]
    [InlineData(true,100,FileSizeUnit.Byte,100)]
    [InlineData(true,1,FileSizeUnit.Kilobyte,1023)]
    [InlineData(true,100,FileSizeUnit.Byte,null)]
    [InlineData(false,50,FileSizeUnit.Byte,100)]
    [InlineData(false,1,FileSizeUnit.Kilobyte,1025)]
    public void Max_File_Size_Test(bool expectedResult,int maxSize,FileSizeUnit unit,int? fileLength)
    {
        //arrange
        var attribute = new MaxFileSizeAttribute(maxSize,unit);
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","file.txt");
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,50,FileSizeUnit.Byte,100)]
    [InlineData(true,100,FileSizeUnit.Byte,100)]
    [InlineData(true,1,FileSizeUnit.Kilobyte,1025)]
    [InlineData(true,100,FileSizeUnit.Byte,null)]
    [InlineData(false,100,FileSizeUnit.Byte,50)]
    [InlineData(false,1,FileSizeUnit.Kilobyte,1023)]
    public void Min_File_Size_Test(bool expectedResult,int minSize,FileSizeUnit unit,int? fileLength)
    {
        //arrange
        var attribute = new MinFileSizeAttribute(minSize,unit);
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","file.txt");
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,100,50,FileSizeUnit.Byte,75)]
    [InlineData(true,100,50,FileSizeUnit.Byte,100)]
    [InlineData(true,100,50,FileSizeUnit.Byte,50)]
    [InlineData(true,2,1,FileSizeUnit.Kilobyte,2000)]
    [InlineData(true,100,50,FileSizeUnit.Byte,null)]
    [InlineData(false,100,50,FileSizeUnit.Byte,101)]
    [InlineData(false,100,50,FileSizeUnit.Byte,49)]
    [InlineData(false,2,1,FileSizeUnit.Kilobyte,1023)]
    [InlineData(false,2,1,FileSizeUnit.Kilobyte,2049)]
    public void Range_File_Size_Test(bool expectedResult,int maxSize,int minSize,FileSizeUnit unit,int? fileLength)
    {
        //arrange
        var attribute = new RangeFileSizeAttribute(maxSize,minSize,unit);
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","file.txt");
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(50,100,FileSizeUnit.Byte)]
    public void Range_File_Size_Throw_Exception_Test(int maxSize,int minSize,FileSizeUnit unit)
        => Assert.Throws<ArgumentException>(() => new RangeFileSizeAttribute(maxSize,minSize,unit));

    [Theory]
    [InlineData(true,false,new string[] { "image/png","image/jpeg" },"image/jpeg",100)]
    [InlineData(true,true,new string[] { ".png",".gif" },"image/gif",100)]
    [InlineData(true,true,new string[] { "png","jpg" },"image/jpeg",100)]
    [InlineData(true,false,new string[] { "image/png","image/jpeg" },"image/gif",null)]
    [InlineData(false,true,new string[] { "png","pdf" },"image/gif",100)]
    [InlineData(false,true,new string[] { ".png",".pdf" },"image/gif",100)]
    [InlineData(false,false,new string[] { "image/png","image/jpeg" },"image/gif",100)]
    [InlineData(false,true,new string[] { ".png","image/jpeg" },"image/jpeg",100)]
    [InlineData(false,false,new string[] { ".png","image/jpeg" },"image/png",100)]
    public void Allowed_File_Extensions_Test(bool expectedResult,bool isExtension,string[] allowedContentTypes,string fileContentType,int? fileLength)
    {
        //arrange
        var attribute = new AllowedFileExtensionsAttribute(isExtension,allowedContentTypes);
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","Test");
        if(formFile is not null)
        {
            formFile.Headers = new HeaderDictionary();
            formFile.Headers.ContentType = fileContentType;
        }
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }

    [Theory]
    [InlineData(true,true,new string[] { "png","pdf" },"image/gif",100)]
    [InlineData(true,true,new string[] { ".png",".pdf" },"image/gif",100)]
    [InlineData(true,false,new string[] { "image/png","image/jpeg" },"image/gif",100)]
    [InlineData(true,true,new string[] { ".png","image/jpeg" },"image/jpeg",100)]
    [InlineData(true,false,new string[] { ".png","image/jpeg" },"image/png",100)]
    [InlineData(true,false,new string[] { "image/png","image/jpeg" },"image/gif",null)]
    [InlineData(false,false,new string[] { "image/png","image/jpeg" },"image/jpeg",100)]
    [InlineData(false,true,new string[] { ".png",".gif" },"image/gif",100)]
    [InlineData(false,true,new string[] { "png","jpg" },"image/jpeg",100)]
    public void Not_Allowed_File_Extensions_Test(bool expectedResult,bool isExtension,string[] allowedContentTypes,string fileContentType,int? fileLength)
    {
        //arrange
        var attribute = new NotAllowedFileExtensionsAttribute(isExtension,allowedContentTypes);
        var formFile = fileLength is null ? null : new FormFile(Stream.Null,0,fileLength.Value,"testFile","Test");
        if(formFile is not null)
        {
            formFile.Headers = new HeaderDictionary();
            formFile.Headers.ContentType = fileContentType;
        }
        //act
        var isValid = attribute.IsValid(formFile);
        //assert
        Assert.Equal(expectedResult,isValid);
    }
}