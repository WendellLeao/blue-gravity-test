using BlueGravity.Events;
using BlueGravity.Gameplay.Assembler;
using BlueGravity.Gameplay.Reception;
using BlueGravity.Services;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravity.UI.Screens.Shop
{
    public sealed class ShopScreen : UIScreen
    {
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private ShopSection[] _sections;
        [SerializeField]
        private ShopTabButton[] _shopTabButtons;
        [SerializeField]
        private ShopPreview _shopPreview;
        [SerializeField]
        private BodyPartsCollectionData _partsCollection;

        private IEventService _eventService;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _eventService = ServiceLocator.GetService<IEventService>();

            _shopPreview.Initialize();
            
            BeginAndPopulateShopSections();

            BeginTabButtons();
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            _shopPreview.Dispose();
            
            DisposeSections();

            DisposeTabButtons();
        }

        protected override void OnSubscribeEvents()
        {
            base.OnSubscribeEvents();
            
            _closeButton.onClick.AddListener(HandleCloseButtonClick);
            
            _shopPreview.OnBodyPartEquipped += HandleBodyPartEquipped;
            _shopPreview.OnBodyPartSold += HandleBodyPartSold;
        }

        protected override void OnUnsubscribeEvents()
        {
            base.OnUnsubscribeEvents();
            
            _closeButton.onClick.RemoveListener(HandleCloseButtonClick);
            
            _shopPreview.OnBodyPartEquipped -= HandleBodyPartEquipped;
            _shopPreview.OnBodyPartSold -= HandleBodyPartSold;
        }

        protected override void OnOpen()
        {
            base.OnOpen();

            ResetTabButtonsState();
            
            _shopTabButtons[0].SetIsInteractable(false);
        }

        protected override void OnClose()
        {
            base.OnClose();
            
            _eventService.DispatchEvent(new InteractShopKeeperEndedEvent());
        }

        private void HandleCloseButtonClick()
        {
            ScreenService.CloseScreenOnTop();
        }

        private void HandleBodyPartEquipped(BodyPartData bodyPartData)
        {
            _eventService.DispatchEvent(new BodyPartBoughtEvent(bodyPartData));
        }
        
        private void HandleBodyPartSold(BodyPartData bodyPartData)
        {
            _eventService.DispatchEvent(new BodyPartSoldEvent(bodyPartData));
        }
        
        private void BeginAndPopulateShopSections()
        {
            for (int i = 0; i < _sections.Length; i++)
            {
                ShopSection section = _sections[i];

                section.OnItemButtonClicked += HandleItemButtonClicked;

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

        private void BeginTabButtons()
        {
            for (int i = 0; i < _shopTabButtons.Length; i++)
            {
                ShopTabButton tabButton = _shopTabButtons[i];

                tabButton.OnButtonClick += HandleTabButtonClick;
                
                tabButton.Initialize(_sections[i]);
            }
        }

        private void HandleTabButtonClick(IShopSection clickedSection)
        {
            ResetTabButtonsState();
            
            for (int i = 0; i < _sections.Length; i++)
            {
                ShopSection section = _sections[i];
                
                section.Close();
            }
            
            clickedSection.Open();
        }
        
        private void ResetTabButtonsState()
        {
            for (int i = 0; i < _shopTabButtons.Length; i++)
            {
                ShopTabButton tabButton = _shopTabButtons[i];

                tabButton.SetIsInteractable(true);
            }
        }

        private void DisposeSections()
        {
            for (int i = 0; i < _sections.Length; i++)
            {
                ShopSection section = _sections[i];

                section.OnItemButtonClicked -= HandleItemButtonClicked;
                
                section.Dispose();
            }
        }

        private void HandleItemButtonClicked(BodyPartData bodyPartData)
        {
            _shopPreview.PreviewBodyPart(bodyPartData);
        }

        private void DisposeTabButtons()
        {
            for (int i = 0; i < _shopTabButtons.Length; i++)
            {
                ShopTabButton tabButton = _shopTabButtons[i];
                
                tabButton.OnButtonClick -= HandleTabButtonClick;
                
                tabButton.Dispose();
            }
        }
    }
}