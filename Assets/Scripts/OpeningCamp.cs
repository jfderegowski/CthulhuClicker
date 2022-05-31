using DG.Tweening;
using Lean.Touch;
using UnityEngine;

public class OpeningCamp : MonoBehaviour
{
    [SerializeField] private GameObject _mainCharacter;
    [SerializeField] private Transform _island;
    [SerializeField] private Transform _camera;
    
    private float _closeIslandDistance;
    private Vector3 _cameraDefaultPosition;
    private Vector3 _cameraDefaultRotation;

    private void Awake()
    {
        _closeIslandDistance = _island.transform.position.z;
        _cameraDefaultPosition = _camera.position;
        _cameraDefaultRotation = _camera.eulerAngles;
        
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
        if (finger.StartScreenPosition.y > finger.ScreenPosition.y-200  && !finger.StartedOverGui)
        {
            _mainCharacter.SetActive(false);
            
            _island.transform
                .DOLocalMoveZ(0f, 0.2f);

            _camera.DOMove(new Vector3(0f,15f,-25f), 0.2f);
            _camera.DORotate(new Vector3(45f, 0f, 0f), 0.2f);
        }

        if (finger.StartScreenPosition.y < finger.ScreenPosition.y+200  && !finger.StartedOverGui)
        {
            _mainCharacter.SetActive(true);
            
            _island.transform
                .DOLocalMoveZ(_closeIslandDistance, 0.2f);

            _camera.DOMove(_cameraDefaultPosition, 0.2f);
            _camera.DORotate(_cameraDefaultRotation, 0.2f);
        }
    }
}
