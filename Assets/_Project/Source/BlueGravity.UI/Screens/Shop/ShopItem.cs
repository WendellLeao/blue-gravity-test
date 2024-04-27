using System;
using BlueGravity.Gameplay.Assembler;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopItem : MonoBehaviour
    {
        public event Action<BodyPartData> OnItemButtonClicked;
        
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private GameObject _noneImageContainer;
        
        private BodyPartData _bodyPartData;
        private bool _isNone;

        public void Setup(BodyPartData bodyPartData, bool isNone)
        {
            _bodyPartData = bodyPartData;
            _isNone = isNone;
            
            _button.onClick.AddListener(HandleButtonClick);

            if (_isNone)
            {
                _noneImageContainer.SetActive(true);
                _itemImage.gameObject.SetActive(false);
                return;
            }

            _itemImage.sprite = _bodyPartData.DisplaySprite;
            _itemImage.SetNativeSize();
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            OnItemButtonClicked?.Invoke(_bodyPartData);
        }
    }
}