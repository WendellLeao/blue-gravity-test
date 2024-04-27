using System.Collections.Generic;
using BlueGravity.Events;
using BlueGravity.Gameplay.Assembler;
using UnityEngine;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopSection : EntityComponent, IShopSection
    {
        [SerializeField]
        private ShopItem _shopItemPrefab;
        [SerializeField]
        private Transform _contentTransform;
        [SerializeField]
        private BodyPartCategoryData _bodyPartCategoryData;
        [SerializeField]
        private BodyPartData _bodyPartNone;

        private readonly List<ShopItem> _shopItems = new();
        private IEventService _eventService;

        public string CategoryId => _bodyPartCategoryData.Id;

        public void Begin(IEventService eventService)
        {
            _eventService = eventService;
            
            base.Begin();
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

        protected override void OnStop()
        {
            base.OnStop();

            DisposeShopItems();
        }

        private void CreateNewShopItem(BodyPartData bodyPartData, bool isNone)
        {
            ShopItem shopItem = Instantiate(_shopItemPrefab, _contentTransform);

            shopItem.OnItemBought += HandleItemBought;

            shopItem.Begin(bodyPartData, isNone);

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