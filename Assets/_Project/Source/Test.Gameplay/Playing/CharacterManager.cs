using UnityEngine;

namespace Test.Gameplay.Playing
{
    public sealed class CharacterManager : Manager
    {
        [SerializeField]
        private Character _character;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _character.Begin();
        }
    }
}