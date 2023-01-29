# Collection Validations

To validate collections

namespace : `Atrob.CollectionValidation`


-  [Collection Count Items](#collectioncountitems)
-  [Collection Max Items](#collectionmaxitems)
-  [Collection Min Items](#collectionminitems)
-  [Collection Max And Min Items](#collectionmaxandminitems)

---
## CollectionCountItems
- **Client validation ❌** 
- Checks that the set contains a certain number of items
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|collectionCountItems|`int`|Number of items that must be in the collection
|isRemoveNulls|`bool`|Remove null items before validation

```csharp
[CollectionCountItems(3)]
public int Number { get; set; }
```

## CollectionMaxItems
- **Client validation ❌** 
- Checks how many items the set can contain at most
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|collectionMaxItems|`int`|Maximum number of items the collection can have
|isRemoveNulls|`bool`|Remove null items before validation

```csharp
[CollectionMaxItems(3)]
public int Number { get; set; }
```

## CollectionMinItems
- **Client validation ❌** 
- Checks the minimum number of items the set must have
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|collectionMinItems|`int`|Minimum items that the collection should have
|isRemoveNulls|`bool`|Remove null items before validation

```csharp
[CollectionMinItems(3)]
public int Number { get; set; }
```

## CollectionMaxItems
- **Client validation ❌** 
- Checks how many items the set can contain at most
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|collectionMaxItems|`int`|Maximum number of items the collection can have
|isRemoveNulls|`bool`|Remove null items before validation

```csharp
[CollectionMaxItems(3)]
public int Number { get; set; }
```

## CollectionMaxAndMinItems
- **Client validation ❌** 
- Checks the maximum and minimum items in the collection
- **parameters**

|Name|Type|Description|
|----|----|-----------|
|collectionMaxItems|`int`|Maximum number of items the collection can have
|collectionMinItems|`int`|Minimum items that the collection should have
|isRemoveNulls|`bool`|Remove null items before validation

```csharp
[CollectionMaxAndMinItems(5,3)]
public int Number { get; set; }
```