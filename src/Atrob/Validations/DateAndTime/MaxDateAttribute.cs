using System.Globalization;

namespace Atrob.Validations.DateAndTime;

/// <summary>
/// Checks the maximum allowed date value
/// </summary>
public class MaxDateAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum date allowed
    /// </summary>
    public DateOnly MaxDate { get; private set; }

    private bool _isNow = false;
    private int _addDays = 0;

    /// <summary>
    /// Checks the maximum allowed date value | Default : DateTime.Now
    /// </summary>
    public MaxDateAttribute() : base(ValidationErrorMessages.MaxDateErrorMessage)
        => _isNow = true;

    /// <summary>
    /// Checks the maximum allowed date value
    /// </summary>
    /// <param name="addDays">Add days to now date</param>
    public MaxDateAttribute(int addDays) : base(ValidationErrorMessages.MaxDateErrorMessage)
        => _addDays = addDays;

    /// <summary>
    /// Checks the maximum allowed date value
    /// </summary>
    /// <param name="maxDate">Maximum date allowed</param>
    public MaxDateAttribute(string maxDate) : base(ValidationErrorMessages.MaxDateErrorMessage)
        => MaxDate = DateOnly.Parse(maxDate);

    /// <summary>
    /// Checks the maximum allowed date value
    /// </summary>
    /// <param name="year">Maximum year allowed</param>
    /// <param name="month">Maximum month allowed</param>
    /// <param name="day">Maximum day allowed</param>
    public MaxDateAttribute(int year,int month,int day) : base(ValidationErrorMessages.MaxDateErrorMessage)
        => MaxDate = new DateOnly(year,month,day);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var date = new DateOnly();
        if(value?.GetType() == typeof(DateTime))
            date = DateOnly.FromDateTime((value as DateTime?)!.Value);
        else
            date = (value as DateOnly?)!.Value;

        if(_isNow)
            MaxDate = DateOnly.FromDateTime(DateTime.Now);
        else if(_addDays > 0)
            MaxDate = DateOnly.FromDateTime(DateTime.Now.AddDays(_addDays));
        return MaxDate >= date;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxDate.ToString("MM/dd/yyyy"));
}