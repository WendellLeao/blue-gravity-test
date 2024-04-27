using BlueGravity.Events;
using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.Rendering
{
    public sealed class RenderingSystem : System
    {
        [SerializeField]
        private Camera _mainCamera;
        [SerializeField]
        private ShopPreviewCamera _shopPreviewCamera;
        
        protected override void OnInitialize()
        {
            base.OnInitialize();

            IEventService eventService = ServiceLocator.GetService<IEventService>();
            ICameraService cameraService = ServiceLocator.GetService<ICameraService>();

            cameraService.SetMainCamera(_mainCamera);
            
            _shopPreviewCamera.Begin(eventService);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _shopPreviewCamera.Stop();
        }
    }
}