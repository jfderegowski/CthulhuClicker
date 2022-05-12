using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodButton : MonoBehaviour
{
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private UpdateScoreUI _updateScoreUI;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            _pointsManager.Points = ulong.MaxValue - 1000000;
            _updateScoreUI.UpdateUI(_pointsManager.Points);
            Debug.Log(ulong.MaxValue);
        });
    }
}
