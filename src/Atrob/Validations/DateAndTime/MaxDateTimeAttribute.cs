using System.Globalization;

namespace Atrob.Validations.DateAndTime;

/// <summary>
/// Checks the maximum allowed dateTime value
/// </summary>
public class MaxDateTimeAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum date time allowed
    /// </summary>
    public DateTime MaxDateTime { get; private set; }

    private bool _isNow = false;
    private int _addDays = 0;
    private int _addSeconds = 0;

    /// <summary>
    /// Checks the maximum allowed dateTime value | Default : DateTimeTime.Now
    /// </summary>
    public MaxDateTimeAttribute() : base(ValidationErrorMessages.MaxDateTimeErrorMessage)
        => _isNow = true;

    /// <summary>
    /// Checks the maximum allowed dateTime value
    /// </summary>
    /// <param name="addDays">Add days to now dateTime</param>
    public MaxDateTimeAttribute(int addDays,int addSeconds) : base(ValidationErrorMessages.MaxDateTimeErrorMessage)
        => (_addDays, _addSeconds) = (addDays, addSeconds);

    /// <summary>
    /// Checks the maximum allowed dateTime value
    /// </summary>
    /// <param name="maxDateTime">Maximum dateTime allowed</param>
    public MaxDateTimeAttribute(string maxDateTime) : base(ValidationErrorMessages.MaxDateTimeErrorMessage)
        => MaxDateTime = DateTime.Parse(maxDateTime);

    /// <summary>
    /// Checks the maximum allowed dateTime value
    /// </summary>
    /// <param name="year">Maximum year allowed</param>
    /// <param name="month">Maximum month allowed</param>
    /// <param name="day">Maximum day allowed</param>
    /// <param name="hour">Maximum hour allowed</param>
    /// <param name="minute">Maximum minute allowed</param>
    /// <param name="second">Maximum second allowed</param>
    public MaxDateTimeAttribute(int year,int month,int day,int hour,int minute,int second) : base(ValidationErrorMessages.MaxDateTimeErrorMessage)
        => MaxDateTime = new DateTime(year,month,day,hour,minute,second);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var dateTime = (value as DateTime?)!.Value;

        if(_isNow)
            MaxDateTime = DateTime.Now;
        else if(_addDays > 0 || _addSeconds > 0)
            MaxDateTime = DateTime.Now.AddDays(_addDays).AddSeconds(_addSeconds);

        return MaxDateTime >= dateTime;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
      => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxDateTime.ToString("MM/dd/yyyy HH:mm:ss"));
}