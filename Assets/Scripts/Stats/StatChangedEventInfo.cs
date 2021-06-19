public class StatChangedEventInfo
{
    public float PreviousValue { get; set; }
    public float CurrentValue { get; set; }

    public StatChangedEventInfo(float previousValue, float currentValue)
    {
        PreviousValue = previousValue;
        CurrentValue = currentValue;
    }
}