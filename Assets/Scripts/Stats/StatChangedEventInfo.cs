public class StatChangedEventInfo
{
    public float PreviousValue { get; set; }
    public float CurrentValue { get; set; }
    public float MaxValue { get; set; }

    public StatChangedEventInfo(float previousValue, float currentValue)
    {
        PreviousValue = previousValue;
        CurrentValue = currentValue;
    }

    public StatChangedEventInfo(float previousValue, float currentValue, float maxValue) : this (previousValue, currentValue)
    {
        MaxValue = maxValue;
    }
}