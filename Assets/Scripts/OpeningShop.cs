using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Lean.Touch;

public class OpeningShop : MonoBehaviour
{
    [SerializeField] private Vector3Int _shopPanelOpenPosition;
    [SerializeField] private Vector3Int _shopPanelClosePosition;
    
    private RectTransform _shopPanelTransform;

    private void Awake()
    {
        _shopPanelTransform = GetComponent<RectTransform>();
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
        if (finger.StartScreenPosition.y < finger.ScreenPosition.y)
        {
            _shopPanelTransform
                .DOLocalMove(_shopPanelOpenPosition, 0.5f, false);
        }

    }
}
