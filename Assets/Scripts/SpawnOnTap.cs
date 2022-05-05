using System;
using Lean.Touch;
using TMPro;
using UnityEngine;

public class SpawnOnTap : MonoBehaviour
{
    [SerializeField] private Transform _floatingTextHolder;
    [SerializeField] private Transform _camera;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private Transform _objToSpawn;
    [SerializeField] private LeanScreenDepth ScreenDepth = new LeanScreenDepth(LeanScreenDepth.ConversionType.DepthIntercept);
    
    private void OnEnable()
    {
        LeanTouch.OnFingerTap += Spawn;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= Spawn;
    }

    private void Spawn(LeanFinger finger)
    {
        if (finger.Tap && !finger.StartedOverGui)
        {
            var position = ScreenDepth.Convert(finger.ScreenPosition, gameObject);
            var clone = Instantiate(_objToSpawn, position, _objToSpawn.rotation, _floatingTextHolder);
            clone.LookAt(_camera);
            clone.GetChild(1).GetComponent<TextMeshPro>().text = _pointsManager.CountPointsToAdd().ToString();
        }
    }
}
