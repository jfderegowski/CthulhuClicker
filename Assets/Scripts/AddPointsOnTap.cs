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
        if (!finger.StartedOverGui)
        {
            _pointsManager.AddPoints();
            _scoreDisplay.UpdateUI(_pointsManager.Points);
            Debug.Log("tap");
        }
        
    }
}
