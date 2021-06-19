using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    Text healthText;

    void Start()
    {
        var healthStat = Player.instance.GetHealthStat();
        healthText.text = "Health " + healthStat.CurrentValue + " / " + healthStat.MaxValue;
        healthStat.onValueChanged.AddListener((valueChagedInfo) => UpdateHealthText(valueChagedInfo));        
    }

    void UpdateHealthText(StatChangedEventInfo eventInfo)
    {
        healthText.text = "Health " + eventInfo.CurrentValue + " / " + eventInfo.MaxValue;
    }
}