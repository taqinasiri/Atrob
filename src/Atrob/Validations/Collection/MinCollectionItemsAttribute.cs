using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Collection;

/// <summary>
/// Checks the minimum number of members a set can have
/// </summary>
public class MinCollectionItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Collection min items
    /// </summary>
    public int MinItems { get; init; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    /// Checks the minimum number of members a set can have
    /// </summary>
    /// <param name="minItems">Collection min items</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    public MinCollectionItemsAttribute(int minItems,bool isRemoveNulls = true) : base(ValidationErrorMessages.MinCollectionItemsErrorMessage)
    {
        MinItems = minItems;
        IsRemoveNulls = isRemoveNulls;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var collection = value as IEnumerable<object>;
        if(collection is null)
            return true;
        if(IsRemoveNulls)
            collection = collection?.RemoveNulls();

        return collection?.Count() >= MinItems;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinItems);
}