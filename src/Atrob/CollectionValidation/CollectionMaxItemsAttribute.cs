using System.Globalization;

namespace Atrob.CollectionValidation;

/// <summary>
/// Checks the maximum number of members a set can have
/// </summary>
public class CollectionMaxItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// The maximum number of items the collection can have
    /// </summary>
    public double CollectionMaxItems { get; private set; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionMaxItemsAttribute"/> class.
    /// </summary>
    /// <param name="collectionMaxItems">The maximum number of items the collection can have</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    public CollectionMaxItemsAttribute(int collectionMaxItems, bool isRemoveNulls = true) : base(ErrorMessages.CollectionMaxItemsErrorMessage)
        => (CollectionMaxItems, IsRemoveNulls) = (collectionMaxItems, isRemoveNulls);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var collection = value as IEnumerable<object>;
        if (IsRemoveNulls) collection = collection?.Where(i => i != null);
        return collection?.Count() <= CollectionMaxItems;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, CollectionMaxItems);
}

