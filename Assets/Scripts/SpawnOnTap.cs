using System;
using Lean.Touch;
using UnityEngine;

public class SpawnOnTap : MonoBehaviour
{
    [SerializeField] private Transform _objToSpawn;
    public LeanScreenDepth ScreenDepth = new LeanScreenDepth(LeanScreenDepth.ConversionType.DepthIntercept);
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
        if (finger.Tap)
        {
            var position = ScreenDepth.Convert(finger.ScreenPosition, gameObject);
            var clone = Instantiate(_objToSpawn, position, _objToSpawn.rotation);
            clone.gameObject.SetActive(true);
        }
    }
}
