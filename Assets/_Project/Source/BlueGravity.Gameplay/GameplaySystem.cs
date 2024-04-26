using BlueGravity.Gameplay.Playing;
using BlueGravity.Gameplay.Reception;
using UnityEngine;

namespace BlueGravity.Gameplay
{
    public sealed class GameplaySystem : System
    {
        [SerializeField]
        private CharacterManager _characterManager;
        [SerializeField]
        private ShopKeeperManager _shopKeeperManager;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _characterManager.Initialize();
            _shopKeeperManager.Initialize();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _characterManager.Dispose();
            _shopKeeperManager.Dispose();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            _characterManager.Tick(deltaTime);
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);

            _characterManager.FixedTick(fixedDeltaTime);
        }
    }
}
