using System;
using BlueGravity.Gameplay.Assembler;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopItem : Entity
    {
        public event Action<BodyPartData> OnItemBought;
        
        [SerializeField]
        private Button _button;
        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private GameObject _noneImageContainer;
        
        private BodyPartData _bodyPartData;
        private bool _isNone;

        public void Begin(BodyPartData bodyPartData, bool isNone)
        {
            _bodyPartData = bodyPartData;
            _isNone = isNone;

            base.Begin();
        }

        protected override void OnBegin()
        {
            base.OnBegin();

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

        protected override void OnStop()
        {
            base.OnStop();
            
            _button.onClick.RemoveListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            OnItemBought?.Invoke(_bodyPartData);
        }
    }
}