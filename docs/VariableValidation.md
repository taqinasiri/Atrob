# Variable Validations

To validate variables (value types)

namespace : `Atrob.VariableValidation`


-  [BoolRequired](#boolrequired)

---
## BoolRequired
- **Client validation ✔** 
- It checks that a `bool` must have an `true` value
- **parameters**

|Name|Type|Description|
|----|----|-----------|
mbersDivisible|`int[]`|An array of numbers that must be divisible by one of them

```csharp
[BoolRequired]
public bool Check { get; set; }
```