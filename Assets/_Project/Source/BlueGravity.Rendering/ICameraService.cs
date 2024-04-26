using BlueGravity.GameServices;
using UnityEngine;

namespace BlueGravity.Cameras
{
    public interface ICameraService : IGameService
    {
        public Camera MainCamera { get; }

        public void SetMainCamera(Camera mainCamera);
    }
}
