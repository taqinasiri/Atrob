using System.Globalization;

namespace Atrob.Validations.DateAndTime;

/// <summary>
/// Checks the minimum allowed date value
/// </summary>
public class MinDateAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Minimum date allowed
    /// </summary>
    public DateOnly MinDate { get; private set; }

    private bool _isNow = false;
    private int _addDays = 0;

    /// <summary>
    /// Checks the minimum allowed date value | Default : DateTime.Now
    /// </summary>
    public MinDateAttribute() : base(ValidationErrorMessages.MinDateErrorMessage)
        => _isNow = true;

    /// <summary>
    /// Checks the minimum allowed date value
    /// </summary>
    /// <param name="addDays">Add days to now date</param>
    public MinDateAttribute(int addDays) : base(ValidationErrorMessages.MinDateErrorMessage)
        => _addDays = addDays;

    /// <summary>
    /// Checks the minimum allowed date value
    /// </summary>
    /// <param name="MinDate">minimum date allowed</param>
    public MinDateAttribute(string minDate) : base(ValidationErrorMessages.MinDateErrorMessage)
        => MinDate = DateOnly.Parse(minDate);

    /// <summary>
    /// Checks the minimum allowed date value
    /// </summary>
    /// <param name="year">minimum year allowed</param>
    /// <param name="month">minimum month allowed</param>
    /// <param name="day">minimum day allowed</param>
    public MinDateAttribute(int year,int month,int day) : base(ValidationErrorMessages.MinDateErrorMessage)
        => MinDate = new DateOnly(year,month,day);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var date = new DateOnly();
        if(value?.GetType() == typeof(DateTime))
            date = DateOnly.FromDateTime((value as DateTime?)!.Value);
        else
            date = (value as DateOnly?)!.Value;

        if(_isNow)
            MinDate = DateOnly.FromDateTime(DateTime.Now);
        else if(_addDays > 0)
            MinDate = DateOnly.FromDateTime(DateTime.Now.AddDays(_addDays));
        return MinDate <= date;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinDate.ToString("MM/dd/yyyy"));
}