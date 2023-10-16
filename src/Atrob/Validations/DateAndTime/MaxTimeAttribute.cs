using System.Globalization;

namespace Atrob.Validations.DateAndTime;

/// <summary>
/// Checks the maximum allowed time value
/// </summary>
public class MaxTimeAttribute : ValidationAttributeBase
{
    /// <summary>
    /// Maximum time allowed
    /// </summary>
    public TimeOnly MaxTime { get; private set; }

    private bool _isNow = false;
    private int _addSeconds = 0;

    /// <summary>
    /// Checks the maximum allowed time value | Default : DateTime.Now
    /// </summary>
    public MaxTimeAttribute() : base(ValidationErrorMessages.MaxTimeErrorMessage)
        => _isNow = true;

    /// <summary>
    /// Checks the maximum allowed time value
    /// </summary>
    /// <param name="addSeconds">Add seconds to now date</param>
    public MaxTimeAttribute(int addSeconds) : base(ValidationErrorMessages.MaxTimeErrorMessage)
        => _addSeconds = addSeconds;

    /// <summary>
    /// Checks the maximum allowed time value
    /// </summary>
    /// <param name="maxTime">Maximum date allowed</param>
    public MaxTimeAttribute(string maxTime) : base(ValidationErrorMessages.MaxTimeErrorMessage)
        => MaxTime = TimeOnly.Parse(maxTime);

    /// <summary>
    /// Checks the maximum allowed time value
    /// </summary>
    /// <param name="hour">Maximum hour allowed</param>
    /// <param name="minute">Maximum minute allowed</param>
    /// <param name="second">Maximum second allowed</param>
    public MaxTimeAttribute(int hour,int minute,int second) : base(ValidationErrorMessages.MaxTimeErrorMessage)
        => MaxTime = new TimeOnly(hour,minute,second);

    /// <inheritdoc/>
    public override bool IsValid(object? value)
    {
        var time = new TimeOnly();
        if(value?.GetType() == typeof(DateTime))
            time = TimeOnly.FromDateTime((value as DateTime?)!.Value);
        else
            time = (value as TimeOnly?)!.Value;

        if(_isNow)
            MaxTime = TimeOnly.FromDateTime(DateTime.Now);
        else if(_addSeconds > 0)
            MaxTime = TimeOnly.FromDateTime(DateTime.Now.AddSeconds(_addSeconds));

        return MaxTime >= time;
    }

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
        => string.Format(CultureInfo.CurrentCulture,ErrorMessageString,name,MaxTime.ToString("HH:mm:ss"));
}