using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.Rendering
{
    public interface ICameraService : IGameService
    {
        public Camera MainCamera { get; }

        public void SetMainCamera(Camera mainCamera);
    }
}
