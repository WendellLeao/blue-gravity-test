using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.Cameras
{
    public sealed class RenderingSystem : System
    {
        [SerializeField]
        private Camera _mainCamera;
        
        protected override void OnInitialize()
        {
            base.OnInitialize();

            ICameraService cameraService = ServiceLocator.GetService<ICameraService>();
            
            cameraService.SetMainCamera(_mainCamera);
        }
    }
}