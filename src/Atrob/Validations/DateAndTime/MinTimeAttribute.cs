using System.Globalization;

namespace Atrob.Validations.DateAndTime;

/// <summary>
/// Checks the minimum allowed time value
/// </summary>
public class MinTimeAttribute : ValidationAttributeBase
{
    public TimeOnly MinTime { get; private set; }
    private bool _isNow = false;
    private int _addSeconds = 0;

    /// <summary>
    /// Checks the minimum allowed time value | Default : DateTime.Now
    /// </summary>
    public MinTimeAttribute() : base(ValidationErrorMessages.MinTimeErrorMessage)
        => _isNow = true;

    /// <summary>
    /// Checks the minimum allowed time value
    /// </summary>
    /// <param name="addSeconds">Add seconds to now date</param>
    public MinTimeAttribute(int addSeconds) : base(ValidationErrorMessages.MinTimeErrorMessage)
        => _addSeconds = addSeconds;

    /// <summary>
    /// Checks the minimum allowed time value
    /// </summary>
    /// <param name="minTime">Minimum date allowed</param>
    public MinTimeAttribute(string minTime) : base(ValidationErrorMessages.MinTimeErrorMessage)
        => MinTime = TimeOnly.Parse(minTime);

    /// <summary>
    /// Checks the minimum allowed time value
    /// </summary>
    /// <param name="hour">Minimum hour allowed</param>
    /// <param name="minute">Minimum minute allowed</param>
    /// <param name="second">Minimum second allowed</param>
    public MinTimeAttribute(int hour,int minute,int second) : base(ValidationErrorMessages.MinTimeErrorMessage)
        => MinTime = new TimeOnly(hour,minute,second);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var time = new TimeOnly();
        if(value?.GetType() == typeof(DateTime))
            time = TimeOnly.FromDateTime((value as DateTime?)!.Value);
        else
            time = (value as TimeOnly?)!.Value;

        if(_isNow)
            MinTime = TimeOnly.FromDateTime(DateTime.Now);
        else if(_addSeconds > 0)
            MinTime = TimeOnly.FromDateTime(DateTime.Now.AddSeconds(_addSeconds));

        return MinTime <= time;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MinTime.ToString("HH:mm:ss"));
}