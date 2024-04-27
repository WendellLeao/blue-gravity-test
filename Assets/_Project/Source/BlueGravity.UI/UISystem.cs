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

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _screenService = ServiceLocator.GetService<IScreenService>();

            _screensManager.Initialize();

            _screenService.OpenScreen<HUDScreen>();
            _screenService.OpenScreen<ShopScreen>();
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            _screensManager.Dispose();
        }
    }
}