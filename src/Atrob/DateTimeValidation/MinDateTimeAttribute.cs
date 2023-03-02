using System.Globalization;

namespace Atrob.DateTimeValidation;

public class MinDateTimeAttribute : ValidationAttributeBase, IClientModelValidator
{
    public DateTime MinDateTime { get; private set; }

    public MinDateTimeAttribute(string minDateTime) : base(ErrorMessages.MaxDateTimeErrorMessage)
    => MinDateTime = DateTime.Parse(minDateTime);

    public MinDateTimeAttribute(int year, int month, int day, byte hour = 0, byte minute = 0) : base(ErrorMessages.MinDateTimeErrorMessage)
        => MinDateTime = new DateTime(year, month, day, hour, minute, 0);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var dateTime = value as DateTime?;
        return MinDateTime <= dateTime;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-minDateTime", FormatErrorMessage(context.ModelMetadata.DisplayName!));
        context.MergeAttribute("data-val-mindatetimevalue", MinDateTime.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
      => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MinDateTime.ToString("MM/dd/yyyy HH:mm"));
}

