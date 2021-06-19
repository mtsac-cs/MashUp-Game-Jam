using UnityEngine;
using UnityEngine.Events;

public class StatModel : MonoBehaviour
{
    public UnityEvent<StatChangedEventInfo> onValueChanged;
    public UnityEvent<StatChangedEventInfo> onMaxValueChanged;

    public float CurrentValue { get; private set; }
    public float MaxValue { get; private set; }

    private void Start()
    {
        onValueChanged = new UnityEvent<StatChangedEventInfo>();
        onMaxValueChanged = new UnityEvent<StatChangedEventInfo>();
    }

    public StatModel Init(float maxValue) => Init(maxValue, maxValue);
    public StatModel Init(float currentValue, float maxValue)
    {
        SetMaxValue(maxValue);
        SetValue(currentValue);
        return this;
    }

    public void IncreaseValue(float amount) => SetValue(CurrentValue + amount);
    public void DecreaseValue(float amount) => SetValue(CurrentValue - amount);

    public void SetValue(float value)
    {
        var previousValue = CurrentValue;
        CurrentValue = Mathf.Clamp(value, 0, MaxValue);
        onValueChanged?.Invoke(new StatChangedEventInfo(previousValue, CurrentValue));
    }


    public void IncreaseMaxValue(float amount) => SetMaxValue(MaxValue + amount);
    public void DecreaseMaxValue(float amount) => SetMaxValue(MaxValue - amount);

    public void SetMaxValue(float maxValue)
    {
        var previousValue = MaxValue;
        MaxValue = maxValue;
        onMaxValueChanged?.Invoke(new StatChangedEventInfo(previousValue, MaxValue));
    }
}