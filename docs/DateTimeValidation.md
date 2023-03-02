# File Validations

To validate files

namespace : `Atrob.FileValidation`


-  [Max DateTime](#maxdatetime)
-  [Min DateTime](#mindatetime)
-  [Max Date](#maxdate)
-  [Min Date](#mindate)

---
## MaxDateTime

- **Client validation ✔** 
- Checks that the entered DateTime is not greater than the desired date and time.
- **parameters**

|Name|Type|Description
|----|----|-----------|
|year|`int`|Maximum amount for the year|
|month|`int`|Maximum amount for the month|
|day|`int`|Maximum amount for the day|
|hour|`int`|Maximum amount for hour => **Default = 23**|
|minute|`int`|Maximum amount for the minute  => **Default = 59**|

```csharp
[MaxDateTime(2023,2,13,15,10)]
public DateTime DateTime { get; set; }
```

OR

|Name|Type|Description
|----|----|-----------|
|maxDateTime|`string`|Maximum amount of DateTime as a string|

```csharp
[MaxDateTime("2023-02-12 15:10 PM")]
public DateTime DateTime { get; set; }
```

## MinDateTime

- **Client validation ✔** 
- Checks that the entered DateTime is not smaller than the desired date and time.
- **parameters**

|Name|Type|Description
|----|----|-----------|
|year|`int`|Minimum amount for the year|
|month|`int`|Minimum amount for the month|
|day|`int`|Minimum amount for the day|
|hour|`int`|Minimum amount for hour => **Default = 23**|
|minute|`int`|Minimum amount for the minute  => **Default = 59**|

```csharp
[MinDateTime(2023,2,13,15,10)]
public DateTime DateTime { get; set; }
```

OR

|Name|Type|Description
|----|----|-----------|
|minDateTime|`string`|Maximum amount of DateTime as a string|

```csharp
[MinDateTime("2023-02-12 15:10 PM")]
public DateTime DateTime { get; set; }
```

## MaxDate

- **Client validation ✔** 
- Checks that the entered date is not greater than the desired date.
- **parameters**

|Name|Type|Description
|----|----|-----------|
|year|`int`|Maximum amount for the year|
|month|`int`|Maximum amount for the month|
|day|`int`|Maximum amount for the day|

```csharp
[MaxDate(2023,2,13)]
[DataType(DataType.Date)]
public DateOnly Date { get; set; }
```

OR

|Name|Type|Description
|----|----|-----------|
|maxDate|`string`|Maximum amount of date as a string|

```csharp
[MaxDate("2023-02-12")]
[DataType(DataType.Date)]
public DateOnly Date { get; set; }
```

## MinDate

- **Client validation ✔** 
- Checks that the entered date is not smaller than the desired date.
- **parameters**

|Name|Type|Description
|----|----|-----------|
|year|`int`|Minimum amount for the year|
|month|`int`|Minimum amount for the month|
|day|`int`|Minimum amount for the day|

```csharp
[MinDate(2023,2,13)]
[DataType(DataType.Date)]
public DateOnly Date { get; set; }
```

OR

|Name|Type|Description
|----|----|-----------|
|minDate|`string`|Minimum amount of date as a string|

```csharp
[MinDate("2023-02-12")]
[DataType(DataType.Date)]
public DateOnly Date { get; set; }
```