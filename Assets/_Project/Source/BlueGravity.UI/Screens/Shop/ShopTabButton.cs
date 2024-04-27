using System;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopTabButton : MonoBehaviour
    {
        public event Action<IShopSection> OnButtonClick;
        
        [SerializeField]
        private Button _button;

        private IShopSection _shopSection;

        public void Initialize(IShopSection section)
        {
            _shopSection = section;
            
            _button.onClick.AddListener(HandleButtonClick);
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            OnButtonClick?.Invoke(_shopSection);
            
            SetIsInteractable(false);
        }

        public void SetIsInteractable(bool isInteractable)
        {
            _button.interactable = isInteractable;
        }
    }
}