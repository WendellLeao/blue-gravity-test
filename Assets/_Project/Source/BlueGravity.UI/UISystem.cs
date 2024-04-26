using BlueGravity.GameServices;
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

            OpenTestScreen();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _screensManager.Dispose();
        }
        
        private void OpenTestScreen()
        {
            _screenService.OpenScreen<TestScreen>();
        }
    }
}