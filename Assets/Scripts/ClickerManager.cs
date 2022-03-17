using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private ClickerUi _clickerUi;
    [SerializeField] private Button _clickerButton;

    private int _score;

    private void Start()
    {
        _clickerUi.UpdateUI(_score);
        _clickerButton.onClick.AddListener(AddPoints);
    }

    private void AddPoints()
    {
        _score++;
        _clickerUi.UpdateUI(_score);
    }
}
