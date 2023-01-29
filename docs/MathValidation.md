# Math Validations

To validate numbers based on math

namespace : `Atrob.MathValidation`


-  [Divisibility](#divisibility)

---
## Divisibility
- **Client validation ✔** 
- It checks whether the entered number is divisible by one of the numbers in the divisibility array that we enter
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|numbersDivisible|`int[]`|An array of numbers that must be divisible by one of them

```csharp
[Divisibility(3, 5, 8)]
public int Number { get; set; }
```