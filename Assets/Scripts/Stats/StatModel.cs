using System;
using UnityEngine;
using UnityEngine.Events;

public class StatModel : MonoBehaviour
{
    [NonSerialized]
    public UnityEvent<StatChangedEventInfo> onValueChanged = new UnityEvent<StatChangedEventInfo>();

    [NonSerialized]
    public UnityEvent<StatChangedEventInfo> onMaxValueChanged = new UnityEvent<StatChangedEventInfo>();

    public float CurrentValue { get; private set; }
    public float MaxValue { get; private set; }


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
        onValueChanged?.Invoke(new StatChangedEventInfo(previousValue, CurrentValue, MaxValue));
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