using System;
using Lean.Touch;
using TMPro;
using UnityEngine;

public class SpawnOnTap : MonoBehaviour
{
    [SerializeField] private Transform _floatingTextHolder;
    [SerializeField] private AddPointsOnTap _addPointsOnTap;
    [SerializeField] private RectTransform _objToSpawn;
    
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
            var objPosition = finger.ScreenPosition;
            var objRotation = _objToSpawn.rotation;
            var clone = Instantiate(_objToSpawn, objPosition, objRotation, _floatingTextHolder);

            clone.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"+{_addPointsOnTap.CountPointsToAdd()}";
        }
    }
}
