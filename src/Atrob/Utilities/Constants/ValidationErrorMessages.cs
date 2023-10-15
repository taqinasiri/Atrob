namespace Atrob.Utilities.Constants;

internal static class ValidationErrorMessages
{
    public const string DefaultErrorMessage = "The field {0} is invalid.";

    public const string RequiredFileErrorMessage = "{0} is required file.";
    public const string FileNotEmptyErrorMessage = "{0} cannot be an empty file.";
    public const string MaxFileSizeErrorMessage = "{0} cannot be larger than {1} {2}.";
    public const string MinFileSizeErrorMessage = "{0} cannot be smaller than {1} {2}.";
    public const string RangeFileSizeErrorMessage = "{0} should be between {1} - {2} {3}.";
    public const string AllowedFileExtensionsErrorMessage = "{1} extension is allowed for {0}.";
    public const string NotAllowedFileExtensionsErrorMessage = "{1} extension is not allowed for {0}.";

    public const string CollectionCountItemsErrorMessage = "You can choose {1} items for {0}.";
    public const string MaxCollectionItemsErrorMessage = "You cannot select than {1} items for {0}.";
    public const string MinCollectionItemsErrorMessage = "You cannot select less than {1} items for {0}.";
    public const string RangeCollectionItemsErrorMessage = "You have to choose between {1} - {2} items for {0}.";

    public const string DivisibilityErrorMessage = "{0} must be divisible by {1}.";

    public const string TrueRequiredErrorMessage = "{0} must be true.";

    public const string MaxDateTimeErrorMessage = "{0} cannot be after {1}.";
    public const string MinDateTimeErrorMessage = "{0} cannot be before {1}.";
    public const string MaxDateErrorMessage = "{0} cannot be after {1}.";
    public const string MinDateErrorMessage = "{0} cannot be before {1}.";
    public const string MaxTimeErrorMessage = "{0} cannot be after {1}.";
    public const string MinTimeErrorMessage = "{0} cannot be before {1}.";

    public const string Base64String = "{0} is not Base64 string.";
    public const string MaxBase64SizeErrorMessage = "{0} cannot be larger than {1} {2}.";
    public const string MinBase64SizeErrorMessage = "{0} cannot be smaller than {1} {2}.";
    public const string AllowedBase64FileExtensionsErrorMessage = "{1} extension is allowed for {0}.";
    public const string NotAllowedBase64FileExtensionsErrorMessage = "{1} extension is not allowed for {0}.";
    public const string RangeBase64SizeErrorMessage = "{0} should be between {1} - {2} {3}.";
}