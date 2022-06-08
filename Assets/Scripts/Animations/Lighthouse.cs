using System;
using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class Lighthouse : MonoBehaviour
    {
        [SerializeField] private Transform _lamp;
        [Range(0,10)] [SerializeField] private float _lampRotationSpeed;

        private void Awake()
        {
            _lampRotationSpeed = 11 - _lampRotationSpeed;
            
            _lamp
                .DORotate(new Vector3(0f, 360f, 0f), _lampRotationSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetRelative()
                .SetEase(Ease.Linear);
        }
    }
}
