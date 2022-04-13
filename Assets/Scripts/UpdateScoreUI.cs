using TMPro;
using UnityEngine;

public class UpdateScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    public void UpdateUI(int amount)
    {
        _counterText.text = $"${amount}";
    }
}
