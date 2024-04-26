using BlueGravity.GameServices;
using UnityEngine;

namespace BlueGravity.Cameras
{
    public sealed class CameraService : GameService, ICameraService
    {
        private Camera _mainCamera;

        public Camera MainCamera => _mainCamera;
        
        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<ICameraService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<ICameraService>();
        }

        public void SetMainCamera(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }
    }
}