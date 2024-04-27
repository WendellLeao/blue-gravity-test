using System;
using BlueGravity.Gameplay.Assembler;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopPreview : MonoBehaviour
    {
        public event Action<BodyPartData> OnBodyPartEquipped;
        public event Action<BodyPartData> OnBodyPartSold;
        
        [SerializeField]
        private Button _buyButton;
        [SerializeField]
        private Button _equipButton;
        [SerializeField]
        private Button _sellButton;
        [SerializeField]
        private GameObject _buyButtonsGroup;
        [SerializeField]
        private GameObject _boughtButtonsGroup;

        private BodyPartData _currentBodyPartData;

        public void Initialize()
        {
            _buyButton.onClick.AddListener(HandleBuyButtonClick);
            _equipButton.onClick.AddListener(HandleEquipButtonClick);
            _sellButton.onClick.AddListener(HandleSellButtonClick);
        }

        public void Dispose()
        {
            _buyButton.onClick.RemoveListener(HandleBuyButtonClick);
            _equipButton.onClick.RemoveListener(HandleEquipButtonClick);
            _sellButton.onClick.RemoveListener(HandleSellButtonClick);
        }

        private void HandleBuyButtonClick()
        {
            _currentBodyPartData.SetWasBought(true);

            _equipButton.onClick.Invoke();
            
            PreviewBodyPart(_currentBodyPartData);
        }
        
        private void HandleEquipButtonClick()
        {
            _equipButton.interactable = false;
            
            OnBodyPartEquipped?.Invoke(_currentBodyPartData);
        }

        private void HandleSellButtonClick()
        {
            _currentBodyPartData.SetWasBought(false);
            
            PreviewBodyPart(_currentBodyPartData);
            
            OnBodyPartSold?.Invoke(_currentBodyPartData);
        }
        
        public void PreviewBodyPart(BodyPartData bodyPartData)
        {
            _currentBodyPartData = bodyPartData;
            
            _buyButtonsGroup.SetActive(!_currentBodyPartData.WasBought);
            _boughtButtonsGroup.SetActive(_currentBodyPartData.WasBought);
            
            _equipButton.interactable = !_currentBodyPartData.IsEquipped;
        }
    }
}