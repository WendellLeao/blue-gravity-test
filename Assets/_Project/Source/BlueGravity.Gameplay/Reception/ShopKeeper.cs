using UnityEngine;

namespace BlueGravity.Gameplay.Reception
{
    public sealed class ShopKeeper : Entity
    {
        [SerializeField]
        private ShopKeeperInteraction _shopKeeperInteraction;
        
        protected override void OnBegin()
        {
            base.OnBegin();

            _shopKeeperInteraction.Begin();
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            _shopKeeperInteraction.Stop();
        }
    }
}