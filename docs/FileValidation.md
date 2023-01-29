# File Validations

To validate files

namespace : `Atrob.FileValidation`


-  [File Required](#filerequired)
-  [File Not Empty](#filenotempty)
-  [Max File Size](#maxfilesize)
-  [Min File Size](#minfilesize)
-  [Max And Min File Size](#maxandminfilesize)
-  [Allowed File Extensions](#allowedfileextensions)
-  [Not Allowed File Extensions](#notallowedfileextensions)

---
## FileRequired

- **Client validation ✔** 
- Checks that the file is imported and that the imported file is not an empty file (0 bytes).

```csharp
[FileRequired]
public IFormFile File { get; set; }
```

## FileNotEmpty
- **Client validation ✔** 
- checks that the imported file is not empty (0 bytes).

> The difference with FileRequired is that it is not mandatory to import the file.

```csharp
[FileNotEmpty]
public IFormFile File { get; set; }
```
## MaxFileSize
- **Client validation ✔** 
- Determines the maximum file size
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|maxFileSize|`double`|Maximum file size in **megabytes**|

```csharp
[MaxFileSize(1.5)]
public IFormFile File { get; set; }
```

## MinFileSize
- **Client validation ✔** 
- Determines the minimum file size
**parameters**

|Name|Type|Description|
|----|----|-----------|
|minFileSize|`double`|Minimum file size in **megabytes**|

```csharp
[MinFileSize(0.5)]
public IFormFile File { get; set; }
```

## MaxAndMinFileSize
- **Client validation ✔** 
- Determines the maximum and minimum file size
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|maxFileSize|`double`|Maximum file size in **megabytes**|
|minFileSize|`double`|Minimum file size in **megabytes**|

```csharp
[MaxAndMinFileSize(1.5,0.5)]
public IFormFile File { get; set; }
```

## AllowedFileExtensions
- **Client validation ✔** 
- Specifies the allowed extensions for the file
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|allowedContentTypes|`string[]`|Allowed file content types (**Mime Type**)

```csharp
[AllowedFileExtensions("image/png", "image/jpeg")]
public IFormFile File { get; set; }
```

## NotAllowedFileExtensions
- **Client validation ✔** 
- Specifies the not allowed extensions for the file
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|notAllowedContentTypes|`string[]`|Not allowed file content types  (**Mime Type**)

```csharp
[NotAllowedFileExtensions("image/gif", "application/pdf")]
public IFormFile File { get; set; }
```