using UnityEngine;
using UnityEngine.UI;

public class ShopButtonsController : MonoBehaviour
{
    [SerializeField] private Button _bClothes;
    [SerializeField] private Button _bBuildings;
    [SerializeField] private Button _bSettings;

    [SerializeField] private GameObject _pClothes;
    [SerializeField] private GameObject _pBuildings;
    [SerializeField] private GameObject _pSettings;

    private void Awake()
    {
        _bClothes.onClick.AddListener(delegate
        {
            ClosePanels();
            _pClothes.SetActive(true);
        });
        
        _bBuildings.onClick.AddListener(delegate
        {
            ClosePanels();
            _pBuildings.SetActive(true);
        });
        
        _bSettings.onClick.AddListener(delegate
        {
            ClosePanels();
            _pSettings.SetActive(true);
        });
    }

    private void ClosePanels()
    {
        _pClothes.SetActive(false);
        _pBuildings.SetActive(false);
        _pSettings.SetActive(false);
    }
}
