using System.Globalization;

namespace Atrob.CollectionValidation;

/// <summary>
/// Checks the maximum and minimum number of members a collection can have
/// </summary>
public class CollectionMaxAndMinItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// The maximum number of items the collection can have
    /// </summary>
    public double CollectionMaxItems { get; private set; }

    /// <summary>
    /// The minimum number of items the collection can have
    /// </summary>
    public double CollectionMinItems { get; private set; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionMaxAndMinItemsAttribute"/> class.
    /// </summary>
    /// <param name="collectionMaxItems">The maximum number of items the collection can have</param>
    /// <param name="collectionMinItems">The minimum number of items the collection can have</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    /// <exception cref="ArgumentException">If the <paramref name="collectionMinItems"/> is greater than the <paramref name="collectionMaxItems"/></exception>
    public CollectionMaxAndMinItemsAttribute(int collectionMaxItems, int collectionMinItems, bool isRemoveNulls = true) : base(ErrorMessages.CollectionMaxAndMinItemsErrorMessage)
    {
        if (collectionMinItems >= collectionMaxItems)
            throw new ArgumentException($"{nameof(collectionMinItems)} cannot be less than or equal to {nameof(collectionMaxItems)}");
        CollectionMaxItems = collectionMinItems;
        CollectionMinItems = collectionMaxItems;
        IsRemoveNulls = isRemoveNulls;
    }

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var collection = value as IEnumerable<object>;
        if (IsRemoveNulls) collection = collection?.Where(i => i != null);
        if (collection?.Count() < CollectionMaxItems || collection?.Count() > CollectionMinItems) return false;
        return true;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, CollectionMaxItems, CollectionMinItems);
}

