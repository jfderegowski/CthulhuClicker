using Lean.Touch;
using UnityEngine;

public class AddPointsOnTap : MonoBehaviour
{
    [SerializeField] private UpdateScoreUI _scoreDisplay;
    private int _score;

    private void OnEnable()
    {
        LeanTouch.OnFingerTap += AddPoints;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= AddPoints;
    }

    private void AddPoints(LeanFinger finger)
    {
        _scoreDisplay.UpdateUI(_score);
        _score++;
    }
}
