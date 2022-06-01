using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Patterns
{
    public class PatternItemPreview : MonoBehaviour
    {
        public Transform ButtonBuyTransform => _buttonBuy.transform;
        public Transform ButtonEquipTransform => _buttonEquip.transform;

        [SerializeField] private CharacterDisplay _characterDisplay;
        [SerializeField] private TextMeshProUGUI _itemTitle;
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private Button _buttonEquip;
        [SerializeField] private Button _buttonBuy;
        [SerializeField] private Button _ButtonCloseItemCard;
        
        private void Awake()
        {
            _ButtonCloseItemCard.onClick.AddListener(()=>Destroy(gameObject));
            gameObject.transform.GetChild(0).transform.DOScale(1, 0.2f);
            gameObject.transform.GetChild(1).transform.DOScale(1, 0.2f);
        }

        public void Import(Sprite clothesImage, ItemType itemType, string itemTitle, string itemDescription,
            UnityAction buttonEquip, UnityAction buttonBuy )
        {
            switch (itemType)
            {
                case ItemType.Hat:
                    _characterDisplay.Hat = clothesImage;
                    break;
                case ItemType.Shirt:
                    _characterDisplay.Shirt = clothesImage;
                    break;
                case ItemType.Wings:
                    _characterDisplay.Wings = clothesImage;
                    break;
                case ItemType.Body:
                    _characterDisplay.Body = clothesImage;
                    break;
                case ItemType.Eye:
                    _characterDisplay.Eye = clothesImage;
                    break;
                default: break;
            }

            _itemTitle.text = itemTitle;
            _itemDescription.text = itemDescription;
            
            _buttonBuy.onClick.AddListener(buttonBuy);
            _buttonEquip.onClick.AddListener(buttonEquip);
        }
    }
}
