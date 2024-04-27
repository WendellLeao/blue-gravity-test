using System;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopTabButton : EntityComponent
    {
        public event Action<IShopSection> OnButtonClick;
        
        [SerializeField]
        private Button _button;

        private IShopSection _shopSection;

        public void Begin(IShopSection section)
        {
            _shopSection = section;
            
            base.Begin();
        }
        
        protected override void OnBegin()
        {
            base.OnBegin();
            
            _button.onClick.AddListener(HandleButtonClick);
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            _button.onClick.RemoveListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            OnButtonClick?.Invoke(_shopSection);
        }
    }
}