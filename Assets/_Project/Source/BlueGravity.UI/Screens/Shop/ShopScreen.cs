using System.Collections.Generic;
using BlueGravity.Events;
using BlueGravity.Gameplay.Assembler;
using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopScreen : UIScreen
    {
        [SerializeField]
        private Transform _contentTransform;
        [SerializeField]
        private ShopItem _shopItemPrefab;
        [SerializeField]
        private BodyPartsCollectionData _partsCollection;

        private readonly List<ShopItem> _shopItems = new();
        private IEventService _eventService;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _eventService = ServiceLocator.GetService<IEventService>();
            
            PopulateGridLayoutGroup();
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            DisposeShopItems();
        }

        private void PopulateGridLayoutGroup()
        {
            BodyPartsGroupData[] partsGroups = _partsCollection.BodyPartsGroups;

            for (int i = 0; i < partsGroups.Length; i++)
            {
                BodyPartsGroupData partGroupData = partsGroups[i];

                for (int j = 0; j < partGroupData.BodyPartsData.Length; j++)
                {
                    BodyPartData bodyPartData = partGroupData.BodyPartsData[j];

                    CreateNewShopItem(bodyPartData, partGroupData.CategoryData);
                }
            }
        }

        private void CreateNewShopItem(BodyPartData bodyPartData, BodyPartCategoryData categoryData)
        {
            ShopItem shopItem = Instantiate(_shopItemPrefab, _contentTransform);

            shopItem.OnItemBought += HandleItemBought;

            shopItem.Begin(bodyPartData, categoryData);

            _shopItems.Add(shopItem);
        }

        private void HandleItemBought(BodyPartData bodyPartData)
        {
            _eventService.DispatchEvent(new BodyPartBoughtEvent(bodyPartData));
        }
        
        private void DisposeShopItems()
        {
            for (int i = 0; i < _shopItems.Count; i++)
            {
                ShopItem shopItem = _shopItems[i];

                shopItem.OnItemBought -= HandleItemBought;
            }

            _shopItems.Clear();
        }
    }
}