using System.Globalization;

namespace Atrob.CollectionValidation;

/// <summary>
/// Checks the minimum number of members a set can have
/// </summary>
public class CollectionMinItemsAttribute : ValidationAttributeBase
{
    /// <summary>
    /// The minimum number of items the collection can have
    /// </summary>
    public double CollectionMinItems { get; private set; }

    /// <summary>
    /// Remove null items before validation
    /// </summary>
    public bool IsRemoveNulls { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionMinItemsAttribute"/> class.
    /// </summary>
    /// <param name="collectionMinItems">The minimum number of items the collection can have</param>
    /// <param name="isRemoveNulls">Remove null items before validation</param>
    public CollectionMinItemsAttribute(int collectionMinItems, bool isRemoveNulls = true) : base(ErrorMessages.CollectionMinItemsErrorMessage)
        => (CollectionMinItems, IsRemoveNulls) = (collectionMinItems, isRemoveNulls);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var collection = value as IEnumerable<object>;
        if (IsRemoveNulls) collection = collection?.Where(i => i != null);
        return (collection?.Count() < CollectionMinItems) ? false : true;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, CollectionMinItems);
}

