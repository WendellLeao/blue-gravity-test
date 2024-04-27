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
        
        private BodyPartData _bodyPartData;
        private BodyPartCategoryData _categoryData;

        public void Begin(BodyPartData bodyPartData, BodyPartCategoryData categoryData)
        {
            _bodyPartData = bodyPartData;
            _categoryData = categoryData;
            
            base.Begin();
        }

        protected override void OnBegin()
        {
            base.OnBegin();

            _button.onClick.AddListener(HandleButtonClick);
            
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