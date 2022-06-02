using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class ShakeCthulhuOnTap : MonoBehaviour
{
    private void OnEnable()
    {
        LeanTouch.OnFingerTap += Shake;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= Shake;
    }

    private void Shake(LeanFinger finger)
    {
        if (!finger.StartedOverGui)
        {
            gameObject.transform
                .DOShakeRotation(0.5f, 1, 10, 90, true);
        }
    }
}
