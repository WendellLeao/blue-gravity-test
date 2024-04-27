using UnityEngine;

namespace BlueGravity.Services
{
    public sealed class GameServicesSystem : System
    {
        [SerializeField]
        private GameService[] _gameServices;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (GameService gameService in _gameServices)
            {
                gameService.Initialize();
            }

            DontDestroyOnLoad(gameObject);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            foreach (GameService gameService in _gameServices)
            {
                gameService.Dispose();
            }
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            foreach (GameService gameService in _gameServices)
            {
                gameService.Tick(deltaTime);
            }
        }
    }
}