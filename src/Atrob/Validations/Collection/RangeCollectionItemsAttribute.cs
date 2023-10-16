using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Collection;

/// <summary>
/// Checks the maximum and minimum number of members a collection can have
/// </summary>
public class RangeCollectionItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Collection min items
    /// </summary>
    public int MinItems { get; init; }

    /// <summary>
    /// Collection max items
    /// </summary>
    public int MaxItems { get; init; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    /// Checks the maximum and minimum number of members a collection can have
    /// </summary>
    /// <param name="maxItems">Collection max items</param>
    /// <param name="minItems">Collection min items</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    /// <exception cref="ArgumentException"></exception>
    public RangeCollectionItemsAttribute(int maxItems,int minItems,bool isRemoveNulls = true) : base(ValidationErrorMessages.RangeCollectionItemsErrorMessage)
    {
        if(minItems > maxItems)
            throw new ArgumentException($"{minItems} cannot be less than or equal to {maxItems}");
        MaxItems = maxItems;
        MinItems = minItems;
        IsRemoveNulls = isRemoveNulls;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var collection = value as IEnumerable<object>;
        if(IsRemoveNulls)
            collection = collection?.RemoveNulls();
        return collection?.Count() <= MaxItems && collection?.Count() >= MinItems;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxItems,MinItems);
}