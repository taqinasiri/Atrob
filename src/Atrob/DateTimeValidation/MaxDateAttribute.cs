using System.Globalization;

namespace Atrob.DateTimeValidation;

public class MaxDateAttribute : ValidationAttributeBase, IClientModelValidator
{
    public DateOnly MaxDate { get; private set; }

    public MaxDateAttribute(string maxDate) : base(ErrorMessages.MaxDateErrorMessage)
        => MaxDate = DateOnly.Parse(maxDate);

    public MaxDateAttribute(int year, int month, int day) : base(ErrorMessages.MaxDateErrorMessage)
        => MaxDate = new DateOnly(year, month, day);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var date = new DateOnly();
        if (value?.GetType() == typeof(DateTime)) 
            date = DateOnly.FromDateTime((value as DateTime?)!.Value);
        else 
            date = (value as DateOnly?)!.Value;
        return MaxDate >= date;
    }

    /// <inheritdoc/>
    public void AddValidation(ClientModelValidationContext context)
    {
        context.MergeAttribute("data-val", "true");
        context.MergeAttribute("data-val-maxDate", FormatErrorMessage(context.ModelMetadata.DisplayName!));
        context.MergeAttribute("data-val-maxdatevalue", MaxDate.ToString());
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
      => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MaxDate.ToString("MM/dd/yyyy"));
}

