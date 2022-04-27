using Lean.Touch;
using UnityEngine;

public class AddPointsOnTap : MonoBehaviour
{
    [SerializeField] private UpdateScoreUI _scoreDisplay;
    [SerializeField] private PointsManager _pointsManager;

    private void OnEnable()
    {
        LeanTouch.OnFingerTap += AddPointsAndUpdateUI;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= AddPointsAndUpdateUI;
    }

    private void AddPointsAndUpdateUI(LeanFinger finger)
    {
        _pointsManager.AddPoints();
        _scoreDisplay.UpdateUI(_pointsManager.Points);
    }
}
