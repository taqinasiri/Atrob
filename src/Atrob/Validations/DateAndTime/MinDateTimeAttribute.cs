using System.Globalization;

namespace Atrob.Validations.DateAndTime;

/// <summary>
/// Checks the minimum allowed dateTime value
/// </summary>
public class MinDateTimeAttribute : ValidationAttributeBase
{
    public DateTime MinDateTime { get; private set; }
    private bool _isNow = false;
    private int _addDays = 0;
    private int _addSeconds = 0;

    /// <summary>
    /// Checks the minimum allowed dateTime value | Default : DateTimeTime.Now
    /// </summary>
    public MinDateTimeAttribute() : base(ValidationErrorMessages.MinDateTimeErrorMessage)
        => _isNow = true;

    /// <summary>
    /// Checks the minimum allowed dateTime value
    /// </summary>
    /// <param name="addDays">Add days to now dateTime</param>
    public MinDateTimeAttribute(int addDays,int addSeconds) : base(ValidationErrorMessages.MinDateTimeErrorMessage)
        => (_addDays, _addSeconds) = (addDays, addSeconds);

    /// <summary>
    /// Checks the minimum allowed dateTime value
    /// </summary>
    /// <param name="minDateTime">Minimum dateTime allowed</param>
    public MinDateTimeAttribute(string minDateTime) : base(ValidationErrorMessages.MinDateTimeErrorMessage)
        => MinDateTime = DateTime.Parse(minDateTime);

    /// <summary>
    /// Checks the minimum allowed dateTime value
    /// </summary>
    /// <param name="year">Minimum year allowed</param>
    /// <param name="month">Minimum month allowed</param>
    /// <param name="day">Minimum day allowed</param>
    /// <param name="hour">Minimum hour allowed</param>
    /// <param name="minute">Minimum minute allowed</param>
    /// <param name="second">Minimum second allowed</param>
    public MinDateTimeAttribute(int year,int month,int day,int hour,int minute,int second) : base(ValidationErrorMessages.MinDateTimeErrorMessage)
        => MinDateTime = new DateTime(year,month,day,hour,minute,second);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var dateTime = (value as DateTime?)!.Value;

        if(_isNow)
            MinDateTime = DateTime.Now;
        else if(_addDays > 0 || _addSeconds > 0)
            MinDateTime = DateTime.Now.AddDays(_addDays).AddSeconds(_addSeconds);

        return MinDateTime <= dateTime;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
      => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinDateTime.ToString("MM/dd/yyyy HH:mm:ss"));
}