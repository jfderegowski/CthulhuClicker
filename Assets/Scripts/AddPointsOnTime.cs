using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class AddPointsOnTime : MonoBehaviour
{
    [FormerlySerializedAs("_itemDisplay")] [SerializeField] private BuildingsShopPanel buildingsShopPanel;
    [SerializeField] private float _time;
    
    private void Start()
    {
        StartCoroutine(WaitAndAdd(_time));
    }
    
    IEnumerator WaitAndAdd(float waitTime)
    {
        yield return WaitAndAdd(waitTime);
    }
}