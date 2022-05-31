using DG.Tweening;
using UnityEngine;
using Lean.Touch;

public class OpeningShop : MonoBehaviour
{
    private RectTransform _shopPanelTransform;
    private float _closeShopPanelPosition;

    private void Awake()
    {
        _shopPanelTransform = GetComponent<RectTransform>();
        _closeShopPanelPosition = _shopPanelTransform.transform.localPosition.x;
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerSwipe += HandleFingerSwipe;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
    }

    private void HandleFingerSwipe(LeanFinger finger)
    {
        if (finger.StartScreenPosition.x > finger.ScreenPosition.x-200 && !finger.StartedOverGui)
        {
            _shopPanelTransform
                .DOLocalMoveX(0f, 0.2f);
        }

        if (finger.StartScreenPosition.x < finger.ScreenPosition.x+200 && !finger.StartedOverGui)
        {
            _shopPanelTransform
                .DOLocalMoveX(_closeShopPanelPosition, 0.2f);
        }
    }
}
