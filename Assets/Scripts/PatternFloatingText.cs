using DG.Tweening;
using UnityEngine;

namespace Patterns
{
    public class PatternFloatingText : MonoBehaviour
    {
        private void Start()
        {
            gameObject.transform
                .DOScale(0, 2f);
        
            gameObject.transform
                .DOMoveY(gameObject.transform.position.y+100, 2f);
        }
    }
}
