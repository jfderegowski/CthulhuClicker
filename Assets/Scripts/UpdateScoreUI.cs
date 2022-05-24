using TMPro;
using UnityEngine;

public class UpdateScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    public void UpdateUI(ulong amount)
    {
        string unit = null;
        float result = amount;

        if (amount >= 1000)
        {
            result = amount / 1000;
            unit = "K";
        }
        if (amount >= 1000000)
        {
            result = amount / 1000000;
            unit = "M";
        }
        if (amount >= 1000000000)
        {
            result = amount / 1000000000;
            unit = "B";
        }
        if (amount >= 1000000000000)
        {
            result = amount / 1000000000000;
            unit = "T";
        }

        _counterText.text = unit != null ? $"${result:F2}{unit}" : $"${result}";
    }
}
