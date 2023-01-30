using System.Globalization;

namespace Atrob.CollectionValidation;

/// <summary>
/// Checks if a set has a certain number of members
/// </summary>
public class CollectionCountItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// The Number of items that must be in the collection
    /// </summary>
    public double CollectionCountItems { get; private set; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    ///  Initializes a new instance of the <see cref="CollectionCountItemsAttribute"/> class.
    /// </summary>
    /// <param name="collectionCountItems">The number of items that must be in the collection</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    public CollectionCountItemsAttribute(int collectionCountItems, bool isRemoveNulls = true) : base(ErrorMessages.CollectionCountItemsErrorMessage)
        => (CollectionCountItems, IsRemoveNulls) = (collectionCountItems, isRemoveNulls);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var collection = value as IEnumerable<object>;
        if (IsRemoveNulls) collection = collection?.Where(i => i != null);
        return (collection?.Count() != CollectionCountItems) ? false : true;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, CollectionCountItems);
}

