using UnityEngine;
using UnityEngine.UI;

namespace GameSettings
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private Button _buttonAudio;
        [SerializeField] private GameObject _audio;
        [SerializeField] private Sprite _audioMute;
        [SerializeField] private Sprite _audioUnMute;

        private void Awake()
        {
            _buttonAudio.onClick.AddListener(delegate
            {
                if (_audio.activeSelf)
                {
                    _audio.transform.GetChild(2).GetComponent<AudioSource>().Play();
                    _audio.SetActive(false);
                    _buttonAudio.GetComponent<Image>().sprite = _audioMute;
                }
                else
                {
                    _audio.SetActive(true);
                    _audio.transform.GetChild(2).GetComponent<AudioSource>().Play();
                    _buttonAudio.GetComponent<Image>().sprite = _audioUnMute;
                }
            });
        }
    }
}
