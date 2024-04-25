using BlueGravity.Gameplay.Playing;
using UnityEngine;

namespace BlueGravity.Gameplay
{
    public sealed class GameplaySystem : System
    {
        [SerializeField]
        private CharacterManager _characterManager;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _characterManager.Initialize();
        }
    }
}
