using BlueGravity.Events;
using BlueGravity.Gameplay.Assembler;
using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopScreen : UIScreen
    {
        [SerializeField]
        private ShopSection[] _sections;
        [SerializeField]
        private BodyPartsCollectionData _partsCollection;

        private IEventService _eventService;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _eventService = ServiceLocator.GetService<IEventService>();
            
            BeginAndPopulateShopSections();
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            StopSections();
        }

        private void BeginAndPopulateShopSections()
        {
            for (int i = 0; i < _sections.Length; i++)
            {
                ShopSection section = _sections[i];

                section.Begin(_eventService);
                
                PopulateShopSection(section);
            }
        }

        private void PopulateShopSection(ShopSection section)
        {
            for (int i = 0; i < _partsCollection.BodyPartsGroups.Length; i++)
            {
                BodyPartsGroupData bodyPartsGroups = _partsCollection.BodyPartsGroups[i];

                if (bodyPartsGroups.CategoryData.Id.Contains(section.CategoryId))
                {
                    BodyPartData defaultBodyPart = bodyPartsGroups.CategoryData.DefaultBodyPart;
                    
                    bool hasNone = !defaultBodyPart.IsVisible;
                    
                    section.PopulateGridLayoutGroup(bodyPartsGroups.BodyPartsData, hasNone);
                }
            }
        }

        private void StopSections()
        {
            for (int i = 0; i < _sections.Length; i++)
            {
                ShopSection section = _sections[i];
                
                section.Stop();
            }
        }
    }
}