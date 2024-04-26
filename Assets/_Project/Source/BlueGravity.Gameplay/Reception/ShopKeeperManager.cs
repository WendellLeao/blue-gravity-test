using UnityEngine;

namespace BlueGravity.Gameplay.Reception
{
    public sealed class ShopKeeperManager : Manager
    {
        [SerializeField]
        private ShopKeeper _shopKeeper;
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _shopKeeper.Begin();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _shopKeeper.Stop();
        }
    }
}
