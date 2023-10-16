using Atrob.Utilities.Extensions;
using System.Globalization;

namespace Atrob.Validations.Collection;

/// <summary>
/// Checks the maximum number of members a set can have
/// </summary>
public class MaxCollectionItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Collection max items
    /// </summary>
    public int MaxItems { get; init; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    /// Checks the maximum number of members a set can have
    /// </summary>
    /// <param name="maxItems">Collection max items</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    public MaxCollectionItemsAttribute(int maxItems,bool isRemoveNulls = true) : base(ValidationErrorMessages.MaxCollectionItemsErrorMessage)
    {
        MaxItems = maxItems;
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

        return collection?.Count() <= MaxItems;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxItems);
}