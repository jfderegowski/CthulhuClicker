using Lean.Touch;
using UnityEngine;

public class AddPointsOnTap : MonoBehaviour
{
    [SerializeField] private UpdateScoreUI _updateScoreUI;
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
            _pointsManager.AddPoints(CountPointsToAdd());
            _updateScoreUI.UpdateUI(_pointsManager.Points);
        }
    }

    public ulong CountPointsToAdd()
    {
        ulong pointsToAdd = _pointsManager.BuildingsShopPanel.Follower.Mps;
        return pointsToAdd;
    }
}
