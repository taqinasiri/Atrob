using System.Globalization;

namespace Atrob.DateTimeValidation;

public class MaxDateTimeAttribute : ValidationAttributeBase, IClientModelValidator
{
    public DateTime MaxDateTime { get; private set; }

    public MaxDateTimeAttribute(string maxDateTime) :base(ErrorMessages.MaxDateTimeErrorMessage) 
        => MaxDateTime = DateTime.Parse(maxDateTime);

    public MaxDateTimeAttribute(int year, int month, int day, int hour = 23, int minute = 59) : base(ErrorMessages.MaxDateTimeErrorMessage)
        => MaxDateTime = new DateTime(year, month, day, hour, minute, 59);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var dateTime = value as DateTime?;
        return MaxDateTime >= dateTime;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-maxDateTime", FormatErrorMessage(context.ModelMetadata.DisplayName!));
        context.MergeAttribute("data-val-maxdatetimevalue", MaxDateTime.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
      => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MaxDateTime.ToString("MM/dd/yyyy HH:mm"));
}

