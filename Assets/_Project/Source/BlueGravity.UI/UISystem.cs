using UnityEngine;

namespace BlueGravity.UI
{
    public sealed class UISystem : System
    {
        [SerializeField]
        private ScreensManager _screensManager;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _screensManager.Initialize();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _screensManager.Dispose();
        }
    }
}