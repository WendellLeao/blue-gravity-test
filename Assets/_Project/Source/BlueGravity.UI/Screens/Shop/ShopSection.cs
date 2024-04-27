using System;
using System.Collections.Generic;
using BlueGravity.Gameplay.Assembler;
using UnityEngine;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopSection : MonoBehaviour, IShopSection
    {
        public event Action<BodyPartData> OnItemButtonClicked;
        
        [SerializeField]
        private ShopItem _shopItemPrefab;
        [SerializeField]
        private Transform _contentTransform;
        [SerializeField]
        private BodyPartCategoryData _bodyPartCategoryData;
        [SerializeField]
        private BodyPartData _bodyPartNone;

        private readonly List<ShopItem> _shopItems = new();

        public string CategoryId => _bodyPartCategoryData.Id;

        public void Dispose()
        {
            DisposeShopItems();
        }
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void PopulateGridLayoutGroup(BodyPartData[] bodyParts, bool hasNone)
        {
            if (hasNone)
            {
                CreateNewShopItem(_bodyPartNone, isNone: true);
            }
            
            for (int i = 0; i < bodyParts.Length; i++)
            {
                BodyPartData bodyPartData = bodyParts[i];

                CreateNewShopItem(bodyPartData, isNone: false);
            }
        }
        
        private void CreateNewShopItem(BodyPartData bodyPartData, bool isNone)
        {
            ShopItem shopItem = Instantiate(_shopItemPrefab, _contentTransform);

            shopItem.OnItemButtonClicked += HandleItemButtonClicked;

            shopItem.Setup(bodyPartData, isNone);

            _shopItems.Add(shopItem);
        }

        private void HandleItemButtonClicked(BodyPartData bodyPartData)
        {
            OnItemButtonClicked?.Invoke(bodyPartData);
        }
        
        private void DisposeShopItems()
        {
            for (int i = 0; i < _shopItems.Count; i++)
            {
                ShopItem shopItem = _shopItems[i];

                shopItem.OnItemButtonClicked -= HandleItemButtonClicked;
                
                shopItem.Dispose();
            }

            _shopItems.Clear();
        }
    }
}