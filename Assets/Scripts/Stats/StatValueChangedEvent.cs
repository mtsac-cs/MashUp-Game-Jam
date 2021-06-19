public class StatValueChangedEvent
{
    public float PreviousValue { get; set; }
    public float CurrentValue { get; set; }

    public StatValueChangedEvent(float previousValue, float currentValue)
    {
        PreviousValue = previousValue;
        CurrentValue = currentValue;
    }
}