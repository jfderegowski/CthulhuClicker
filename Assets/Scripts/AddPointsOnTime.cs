using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class AddPointsOnTime : MonoBehaviour
{
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private UpdateScoreUI _updateScoreUI;
    [SerializeField] private float _time;
    
    private void Start()
    {
        StartCoroutine(WaitAndAdd(_time));
    }
    
    private IEnumerator WaitAndAdd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        _pointsManager.AddPoints(CountPointsToAdd());
        _updateScoreUI.UpdateUI(_pointsManager.Points);
        
        StartCoroutine(WaitAndAdd(_time));
    }

    private ulong CountPointsToAdd()
    {
        ulong pointsToAdd = 0;

        foreach (var building in _pointsManager.BuildingsShopPanel.Buildings)
        {
            if (building.Lvl > 0)
            {
                pointsToAdd += building.Mps * building.Lvl;
            }
            
        }

        return pointsToAdd;
    }
}