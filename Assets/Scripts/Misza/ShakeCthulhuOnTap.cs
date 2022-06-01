using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class ShakeCthulhuOnTap : MonoBehaviour
{
    public GameObject Cthulhu;
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
        Debug.Log("shake");
        //Cthulhu.transform.DOShakeScale(0.5f, 1, 10, 90, true);
        Cthulhu.transform.DOShakeRotation(0.5f, 1, 10, 90, true);
    }
}
