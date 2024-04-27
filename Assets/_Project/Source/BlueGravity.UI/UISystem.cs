using BlueGravity.Events;
using BlueGravity.Gameplay.Reception;
using BlueGravity.Services;
using BlueGravity.UI.Screens;
using BlueGravity.UI.Screens.Shop;
using UnityEngine;

namespace BlueGravity.UI
{
    public sealed class UISystem : System
    {
        [SerializeField]
        private ScreensManager _screensManager;

        private IScreenService _screenService;
        private IEventService _eventService;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _eventService = ServiceLocator.GetService<IEventService>();
            _screenService = ServiceLocator.GetService<IScreenService>();
            
            _eventService.AddEventListener<InteractShopKeeperStartedEvent>(HandleInteractShopKeeperEvent);

            _screensManager.Initialize();

            _screenService.OpenScreen<HUDScreen>();
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            _eventService.RemoveEventListener<InteractShopKeeperStartedEvent>(HandleInteractShopKeeperEvent);
            
            _screensManager.Dispose();
        }

        private void HandleInteractShopKeeperEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractShopKeeperStartedEvent)
            {
                _screenService.OpenScreen<ShopScreen>();
            }
        }
    }
}