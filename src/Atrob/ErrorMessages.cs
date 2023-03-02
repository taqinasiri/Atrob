namespace Atrob;

/// <summary>
/// A static class to hold the error text ready attributes
/// </summary>
public static class ErrorMessages
{
    public const string DefaultErrorMessage = "The field {0} is invalid.";
    public const string AllowedFileExtensionsErrorMessage = "{1} extension is allowed for {0}.";
    public const string NotAllowedFileExtensionsErrorMessage = "{1} extension is not allowed for {0}.";
    public const string RequiredFileErrorMessage = "{0} Is Required.";
    public const string MaxFileSizeErrorMessage = "{0} cannot be larger than {1}.";
    public const string MinFileSizeErrorMessage = "{0} cannot be smaller than {1} megabyte.";
    public const string MaxAndMinFileSizeErrorMessage = "{0} should be between {1} - {2} megabyte.";
    public const string FileNotEmptyErrorMessage = "{0} cannot be an empty file.";
    public const string DivisibilityErrorMessage = "{0} must be divisible by {1}.";
    public const string BoolValidationErrorMessage = "Tick {0} is required.";
    public const string CollectionCountItemsErrorMessage = "You can choose {1} items for {0}.";
    public const string CollectionMaxItemsErrorMessage = "You cannot select than {1} items for {0}.";
    public const string CollectionMinItemsErrorMessage = "You cannot select less than {1} items for {0}.";
    public const string CollectionMaxAndMinItemsErrorMessage = "You have to choose between {1} - {2} items for {0}.";
    public const string MinDateTimeErrorMessage = "{0} cannot be earlier than {1}.";
    public const string MaxDateTimeErrorMessage = "{0} cannot be later than {1}.";
    public const string MinDateErrorMessage = "{0} cannot be earlier than {1}.";
    public const string MaxDateErrorMessage = "{0} cannot be later than {1}.";
}