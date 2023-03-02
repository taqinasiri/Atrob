using System.Globalization;

namespace Atrob.DateTimeValidation;

public class MinDateAttribute : ValidationAttributeBase, IClientModelValidator
{
    public DateOnly MinDate { get; private set; }

    public MinDateAttribute(string minDate) : base(ErrorMessages.MinDateErrorMessage)
    => MinDate = DateOnly.Parse(minDate);

    public MinDateAttribute(int year, int month, int day) : base(ErrorMessages.MinDateErrorMessage)
        => MinDate = new DateOnly(year, month, day);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var date = new DateOnly();
        if (value?.GetType() == typeof(DateTime))
            date = DateOnly.FromDateTime((value as DateTime?)!.Value);
        else
            date = (value as DateOnly?)!.Value;
        return MinDate <= date;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-minDate", FormatErrorMessage(context.ModelMetadata.DisplayName!));
        context.MergeAttribute("data-val-mindatevalue", MinDate.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
      => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MinDate.ToString("MM/dd/yyyy"));
}

